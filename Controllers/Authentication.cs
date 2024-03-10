using Microsoft.AspNetCore.Mvc;

namespace PMQLSuperbrain_Core.Controllers
{
    public class Authentication : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
