using Microsoft.AspNetCore.Mvc;

namespace handydandy.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
