using Microsoft.AspNetCore.Mvc;

namespace _01_ASPNetMVC.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
