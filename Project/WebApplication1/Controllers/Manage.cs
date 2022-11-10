using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Manage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
