using Microsoft.AspNetCore.Http;
using Mmi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmi.Services.Authentication
{
    public class AuthenticationItemsManager(HttpContext httpContext)
    {
        private const string AuthenticatedPersonKey = "AuthenticatedPerson";

        private readonly HttpContext _context = httpContext;

        public bool TryGetAuthenticatedPerson([MaybeNullWhen(false)]out InsuredPerson person)
        {
            person = null;
            if (!_context.Items.TryGetValue(AuthenticatedPersonKey, out object? temp))
                return false;

            person = temp as InsuredPerson;
            return person != null;
        }

        public void SetAuthenticatedPerson(InsuredPerson person)
        { 
            ArgumentNullException.ThrowIfNull(person);
            _context.Items.Add(AuthenticatedPersonKey, person);
        }

        public void RemoveAuthenticatedPerson(InsuredPerson person)
        {
            ArgumentNullException.ThrowIfNull(person);
            _context.Items.Remove(AuthenticatedPersonKey);
        }
    }
}
