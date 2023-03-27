using Microsoft.AspNetCore.Mvc;

namespace _01_ASPNetMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
