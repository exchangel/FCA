using Microsoft.AspNetCore.Mvc;

namespace FCA.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
