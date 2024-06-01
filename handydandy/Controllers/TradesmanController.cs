using Microsoft.AspNetCore.Mvc;

namespace handydandy.Controllers
{
    public class TradesmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
