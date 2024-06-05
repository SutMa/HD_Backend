using Microsoft.AspNetCore.Mvc;
using handydandy.Models;
using handydandy.RequestBodyModels;
using handydandy.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using handydandy.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace handydandy.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenerateJWT _jwtGenerator;
        public UserController(AppDbContext context, GenerateJWT jwtGenerator)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel userModel)
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


        [HttpPost("login")]
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
                    string token = _jwtGenerator.GenerateJWTToken(user);
                    return Ok(new { Token = token });
                }
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> EditUser([FromBody] UserEditModel userEdit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userIdString = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
            {
                return Unauthorized();
            }
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID format.");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User nolt found");
            }
            user.Name = userEdit.Name;
            user.Address = userEdit.Address;
            user.Zipcode = userEdit.Zipcode;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("User information updated.");
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "An error occurred while updating the user.");
            }

        }





    }
}

