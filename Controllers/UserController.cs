using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Model;
using WebApplication1.Requset;  
using WebApplication1.Responce;  

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
    {
        new User { Username = "admin", Password = "123", Location = "New York" },
    };

        [HttpPost("login")]
        public ActionResult<UserResponse> Login([FromBody] UserRequset request)
        {
            var user = Users.FirstOrDefault(u => u.Username == request.username && u.Password == request.password);

            if (user != null)
            {
  
                var jwt = "dummy_jwt_token";

                var response = new UserResponse
                {
                    username = user.Username,
                    locations = user.Location,
                    jwt = jwt
                };

                return Ok(response);
            }

            return Unauthorized("Invalid username or password.");
        }
    }

}

