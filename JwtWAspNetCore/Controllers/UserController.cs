namespace JwtWAspNetCore.Controllers
{
    using System;
    using System.Net;
    using JwtWAspNetCore.Domain;
    using JwtWAspNetCore.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenGenerator tokenGenerator;

        public UserController(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            this.userRepository = userRepository;
            this.tokenGenerator = tokenGenerator;
        }

        [HttpPost("api/User")]
        [AllowAnonymous]
        public IActionResult ValidateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(HttpStatusCode.BadRequest.ToString(), nameof(user));
            }

            try
            {
                string chainToken = string.Empty;
                User userValidated = this.userRepository.ValidateUser(user);

                if (userValidated == null)
                {
                    throw new ArgumentNullException(HttpStatusCode.NotFound.ToString(), nameof(user));
                }

                chainToken = this.tokenGenerator.CreateJWTToken(userValidated);

                var objToken = new
                {
                    token = chainToken
                };

                return Ok(objToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
