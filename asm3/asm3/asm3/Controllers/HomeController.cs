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
                ViewBag.Out = new Product();
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.ToList();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(string id)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                ViewBag.Selected = id;
                ViewBag.Out = context.Products.FirstOrDefault(item => item.ProductCode.Equals(id));
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.Where(item => item.ProductCode.Equals(id)).ToList();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Name(string txt)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                ViewBag.Out = new Product();
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.Where(p => p.ProductName.Contains(txt)).ToList();
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Image(string txt2)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                ViewBag.Out = new Product();
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.Where(p => p.Image.Contains(txt2)).ToList();
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult Price(string price1, string price2)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                float p1 = float.Parse(price1);
                float p2 = float.Parse(price2);
                ViewBag.Out = new Product();
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.Where(p => p1 < p.Price && p.Price < p2).ToList();
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            using (MyDB3Context context = new MyDB3Context())
            {
                Product p = context.Products.FirstOrDefault(p => p.ProductCode == product.ProductCode);
                p.ProductName = product.ProductName;
                p.Unit = product.Unit;
                p.Price = product.Price;
                p.Image = product.Image;
                context.Products.Update(p);
                context.SaveChanges();
                ViewBag.Out = p;
                ViewBag.ProductsID = context.Products.ToList();
                ViewBag.Products = context.Products.ToList();
            }
            return View("Index");
        }


    }
}
