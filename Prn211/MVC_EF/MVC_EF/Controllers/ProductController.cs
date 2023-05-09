using Microsoft.AspNetCore.Mvc;
using MVC_EF.Models;
using System.Collections.Generic;

namespace MVC_EF.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                var products = context.Products.ToList();
                return View(products);
            }
        }

        [HttpPost]
        public IActionResult Index(int cateId)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                ViewBag.Selected = cateId;
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                var products = context.Products.ToList();
                if (cateId!=0)
                {
                    products = context.Products.Where(p => p.CategoryId == cateId).ToList();
                }
                return View(products);
            }
        }

        public IActionResult Add()
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                return View();
            }
        }


        [HttpPost]
        public IActionResult Add(Product product)
        {

            if (ModelState.IsValid)//Tạo model thành công
            {
                using (MySaleDBContext context = new MySaleDBContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product p = context.Products.FirstOrDefault(p => p.ProductId == id);
                var data1 = context.Categories.ToList();
                ViewBag.Categories = data1;
                return View(p);
            }

        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product p = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
                p.ProductName = product.ProductName;
                p.UnitPrice = product.UnitPrice;
                p.UnitsInStock = product.UnitsInStock;
                p.Image = product.Image;
                p.CategoryId = product.CategoryId;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public IActionResult Delete(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product product = context.Products.FirstOrDefault(ite=>ite.ProductId==id);
                context.Products.Remove(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Detail(int id)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                ViewBag.Product= product;
                return View();
            }
        }
    }
}
