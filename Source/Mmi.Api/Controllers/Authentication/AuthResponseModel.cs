using System.Text.Json.Serialization;

namespace Mmi.Api.Controllers.Authentication
{
    public class AuthResponseModel(string token)
    {
        [JsonPropertyName("token")]
        public string Token { get; } = token;
    }
}
