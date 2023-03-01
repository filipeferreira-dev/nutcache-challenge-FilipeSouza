using Microsoft.AspNetCore.Mvc;

namespace NutcacheChallenge.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index","Employee");
        }
    }
}
