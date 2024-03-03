using System.Text.Json.Serialization;

namespace Mmi.Api.Controllers.Authentication
{
    public class LoginRequestModel
    {
        [JsonPropertyName("email")]
        public required string Email { get; init; }

        [JsonPropertyName("password")]
        public required string Password { get; init; }
    }
}
