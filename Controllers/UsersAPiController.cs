using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPisUserCore.Models;

namespace RestAPisUserCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersAPiController : ControllerBase
    {
        private readonly JwtSettings jwtSettings;
        public UsersAPiController(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }
        private IEnumerable<Users> logins = new List<Users>() {
            new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        Password = "Admin",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        Password = "Admin",
                }
        };
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = logins.Any(x => x.EmailId.Equals(userLogins.EmailID, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.EmailId.Equals(userLogins.EmailID, StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.JwtHelper.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.EmailId,
                        Id = user.Id,
                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        ///// <summary>
        ///// Get List of UserAccounts
        ///// </summary>
        ///// <returns>List Of UserAccounts</returns>
        //[HttpGet]
        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        //public IActionResult GetList()
        //{
        //    return Ok(logins);
        //}

        /// <summary>
        /// Get List of Tasks
        /// </summary>
        /// <returns>List Of UserAccounts</returns>
        [HttpGet]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetListTasks()
        {
            return Ok(logins);
        }
    }
}