using Microsoft.AspNetCore.Mvc;
using asm3.Models;
namespace asm3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                ViewBag.Out = context.Products.First();
                ViewBag.Products = context.Products.ToList();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string id)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                ViewBag.Out = context.Products.FirstOrDefault(item=>item.ProductCode.Equals(id));
                ViewBag.Products = context.Products.ToList();
            }
            return View();
        }
    }
}
