using Microsoft.AspNetCore.Mvc;
using handydandy.Models;
using handydandy.RequestBodyModels;
using handydandy.Data;

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
                var newUser = new User
                {
                    Email = userModel.Email,
                    Password = userModel.Password,
                    Name = userModel.Name,
                    Address = userModel.Address,
                    Zipcode = userModel.Zipcode
                };
                _context.Users.Add(newUser);

                try
                {
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return BadRequest(ex);
                }
       
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        
    }
}

