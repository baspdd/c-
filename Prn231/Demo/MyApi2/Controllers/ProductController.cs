using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi2.Models;

namespace MyApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                return Ok(db.Products.Include(p=>p.Category).ToList());
            }
        }

        [HttpGet("id")]
        public IActionResult GetProductById(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var cate = db.Products.Include(p => p.Category).SingleOrDefault(cate => cate.ProductId == id);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return Ok(db.Products.ToList());
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var check = db.Products.Any(c => c.ProductId == product.ProductId);
                if (!check) return NotFound();
                db.Products.Update(product);
                db.SaveChanges();
                return Ok(db.Products.ToList());
            }
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var c = db.Products.Include(c => c.Category).SingleOrDefault(cate => cate.ProductId == id);
                if (c == null) return NotFound();
                db.Products.Remove(c);
                db.SaveChanges();
                return Ok(db.Products.ToList());
            }
        }
    }
}
