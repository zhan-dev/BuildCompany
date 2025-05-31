using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
