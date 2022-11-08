using Microsoft.AspNetCore.Mvc;
using ASM.Models;
using System.Globalization;

namespace ProjectPRN211.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Tasks()
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                List<Product> products = context.Products.ToList();
                List<Category> cate = context.Categories.ToList();
                ViewBag.Cate1 = cate[0];
                ViewBag.Cate2 = cate[1];

                ViewBag.ListP = context.Products.ToList();
                return View();
            }
        }

        public IActionResult Shop()
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                List<Product> products = context.Products.ToList();
                List<Category> cate = context.Categories.ToList();
                ViewBag.Cate1 = cate[0];
                ViewBag.Cate2 = cate[1];

                ViewBag.ListP = context.Products.ToList();
                return View();
            }
        }


    }
}
