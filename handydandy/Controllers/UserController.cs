using Microsoft.AspNetCore.Mvc;
using handydandy.Models;
using handydandy.RequestBodyModels;
using handydandy.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace handydandy.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult>  CreateUser([FromBody] UserCreateModel userModel)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

                var newUser = new User
                {
                    Email = userModel.Email,
                    Password = hashedPassword,
                    Name = userModel.Name,
                    Address = userModel.Address,
                    Zipcode = userModel.Zipcode
                };
                

                try
                {
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return BadRequest();
                }
       
            }
            else
            {
                return BadRequest();
            }
           
         }


        [HttpGet("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLogin.Email);
                if (user == null)
                {
                    return Unauthorized("No such user exists.");
                }
                if (BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
               
            }
            return Ok();

        }
    }
}

