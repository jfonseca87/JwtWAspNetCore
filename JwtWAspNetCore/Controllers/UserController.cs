namespace JwtWAspNetCore.Controllers
{
    using System;
    using System.Net;
    using JwtWAspNetCore.Domain;
    using JwtWAspNetCore.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost("api/User")]
        public IActionResult ValidateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(HttpStatusCode.BadRequest.ToString(), nameof(user));
            }

            try
            {
                return Ok(this.userRepository.ValidateUser(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
