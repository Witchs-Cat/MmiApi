using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmi.Core.Domain;
using Mmi.Core.Repositories;
using Mmi.Services.Authentication;

namespace Mmi.Api.Controllers.Authentication
{
    [Route("auth")]
    [ApiController]
    public class AuthController(
        IInsuredPersonRepository persons
        ) : ControllerBase
    {
        private readonly IInsuredPersonRepository _persons = persons;

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginData)
        {
            InsuredPerson? person = await _persons.FinByAuthorizationDataAsync(loginData.Email, loginData.Password); 
            if (person == null) 
                return BadRequest();

            SimpleAuthToken token = new(person.Id);

            AuthResponseModel response = new(token.ToString());
            return Ok(response);
        }
    
        [HttpPost("signup")]
        public async Task<IActionResult> Signup()
        {
            InsuredPerson person = new InsuredPerson()
            {
                Id = 0,
                Bithday = DateTimeOffset.UtcNow,
                Contracts = Array.Empty<InsuranceContract>(),
                Name = "am",
                MiddleName = "am",
                Surname = "am",
                Password = "password",
                Email = "1234@mail.com",
                Pemissions = PersonPemissions.None
            };

            await _persons.CreatePersonAsync(person);

            SimpleAuthToken token = new(person.Id);

            AuthResponseModel response = new(token.ToString());
            return Ok(response);
        }
    }
}
