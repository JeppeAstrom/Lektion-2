using Microsoft.AspNetCore.Mvc;

namespace _01_ASPNetMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
