using Microsoft.AspNetCore.Mvc;

namespace MyProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}