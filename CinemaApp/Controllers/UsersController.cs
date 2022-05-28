using CinemaApp.Data;
using CinemaApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private CinemaAppDbContext _dbContext;

        public UsersController(CinemaAppDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public IActionResult Register([FromBody] User user)
        {

            var userWithSameEmail = _dbContext.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if(userWithSameEmail != null)
            {
                return BadRequest("User already exists!");
            }
            else
            {
                var userObj = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,

                };

                _dbContext.Users.Add(userObj);
                _dbContext.SaveChanges();
            }
            return StatusCode(StatusCodes.Status201Created);

        }
    }
}
