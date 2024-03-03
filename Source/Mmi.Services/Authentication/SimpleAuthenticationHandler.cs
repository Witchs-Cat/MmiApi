using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Mmi.Core.Domain;
using Mmi.Core.Repositories;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Mmi.Services.Authentication
{
    public class SimpleAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            IInsuredPersonRepository persons) 
        : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
    {
        private readonly IInsuredPersonRepository _persons = persons;

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!TryGetToken(Request.Headers, out string? authToken))
                return AuthenticateResult.NoResult();

            if (!TryParseToken(authToken, out SimpleAuthToken? tokenData))
                return AuthenticateResult.NoResult();

            InsuredPerson? person = await _persons.FindByIdAsync(tokenData.UserId);
            if (person == null)
                return AuthenticateResult.Fail("UserNotFound");

            AuthenticationItemsManager authManager = new(Context);
            authManager.SetAuthenticatedPerson(person);
            return AuthenticateResult.Success(CreateTicket(person, Scheme));
        }

        private static AuthenticationTicket CreateTicket(InsuredPerson person, AuthenticationScheme scheme) 
        {
            Claim[] claims = [
                new("UserId", person.Id.ToString()),
                new("UserPermissons", person.Pemissions.ToString())
            ];

            ClaimsIdentity identity = new(claims);
            AuthenticationTicket ticket = new(new ClaimsPrincipal(identity), scheme.Name);


            return ticket;
        }

        private static bool TryGetToken(IHeaderDictionary headers, [MaybeNullWhen(false)] out string authToken) 
        {
            authToken = null!;

            if (!headers.TryGetValue(HeaderNames.Authorization, out StringValues header))
                return false;

            authToken = header.ToString();

            return !string.IsNullOrEmpty(authToken);
        }

        private bool TryParseToken(string authToken, [MaybeNullWhen(false)] out SimpleAuthToken tokenData)
        {
            tokenData = null!;
            try
            {
                tokenData = SimpleAuthToken.FromString(authToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
