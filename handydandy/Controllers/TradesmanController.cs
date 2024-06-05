using handydandy.Data;
using handydandy.Helpers;
using handydandy.Models;
using handydandy.RequestBodyModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace handydandy.Controllers
{

    [ApiController]
    [Route("tradesman")]
    public class TradesmanController : Controller
    {
        private readonly AppDbContext _context;
        private readonly GenerateJWT _jwtGenerator;

        public TradesmanController(AppDbContext context, GenerateJWT jwtGenerator)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTradesman([FromBody]  TradesmanCreateModel tradesmanModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(tradesmanModel.Password);

            var newTradesman = new Tradesman
            {
                Email = tradesmanModel.Email,
                Password = tradesmanModel.Password,
                Name = tradesmanModel.Name,
                TradeOccupation = tradesmanModel.TradeOccupation,
                Summary = tradesmanModel.Summary,
                ServiceArea = tradesmanModel.ServiceArea,
            };

            try
            {
                _context.Tradesmans.Add(newTradesman);
                await _context.SaveChangesAsync();
                return Ok("Tradesman Created");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginTradesman([FromBody] TradesmanLoginModel tradesmanLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tradesman = await _context.Tradesmans.FirstOrDefaultAsync(t => t.Email == tradesmanLogin.Email);
            if(tradesman == null)
            {
                return Unauthorized("No such Tradesman exists.");
            }

            if (BCrypt.Net.BCrypt.Verify(tradesmanLogin.Password, tradesman.Password))
            {
                string token = _jwtGenerator.GenerateJWTToken_Tradesman(tradesman);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }

        [Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> EditTradesman([FromBody] TradesmanEditModel tradesmanEdit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var tradesmanIdString = User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.NameIdentifier)?.Value;
            if (tradesmanIdString == null)
            {
                return Unauthorized();
            }

            if(!int.TryParse(tradesmanIdString, out int tradesmanId))
            {
                return BadRequest("Invalid tradesman format");
            }

            var tradesman = await _context.Tradesmans.FindAsync(tradesmanId);
            if (tradesman == null)
            {
                return NotFound("Tradesman not found.");
            }

            tradesman.Name = tradesmanEdit.Name;
            tradesman.Summary = tradesmanEdit.Summary;
            tradesman.ServiceArea = tradesmanEdit.ServiceArea;


        }


    }
}
