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

        public IActionResult Shop(int id)
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                List<Product> products = context.Products.ToList();

                if (id >0)
                {
                    products = context.Products.Where(p => p.Type == id).ToList();
                }

                List<Category> cate = context.Categories.ToList();
                ViewBag.Cate = cate;
                ViewBag.ListP = products;
                return View();
            }
        }

        public IActionResult Search(string txt)
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                List<Product> products = context.Products.Where(p=>p.Title.ToLower().Contains(txt.ToLower())).ToList();
                List<Category> cate = context.Categories.ToList();
                ViewBag.Cate = cate;
                ViewBag.ListP = products;
                return View("Shop");
            }
        }
        [HttpPost]
        IActionResult Login(string name , string pass)
        {
            using (ASMSSContext context = new ASMSSContext())
            {
                User us = context.Users.FirstOrDefault(u=>u.Username.Equals(name, StringComparison.OrdinalIgnoreCase) && u.Password.Equals(pass, StringComparison.OrdinalIgnoreCase));
                if (us!=null)
                {
                }
                return Tasks();
            }
        }

    }
}
