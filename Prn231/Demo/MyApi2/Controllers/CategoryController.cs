using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi2.Models;

namespace MyApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Get:api/Category
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                return Ok(db.Categories.ToList());
            }
        }
        //Get:api/Category/id
        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var cate = db.Categories.SingleOrDefault(cate => cate.CategoryId == id);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }
        //Get:api/Category/name
        [HttpGet("name")]
        public IActionResult GetCategoryByName(string name)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var cate = db.Categories.Where(cate => cate.CategoryName.Contains(name)).ToList();
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }

        //Post:api/Category
        [HttpPost]
        public IActionResult AddCategory(Category cate)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                db.Categories.Add(cate);
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category cate)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var check = db.Categories.Any(c => c.CategoryId == cate.CategoryId);
                if (!check) return NotFound();
                db.Categories.Update(cate);
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using (MySaleDBContext db = new MySaleDBContext())
            {
                var c = db.Categories.Include(c => c.Products).SingleOrDefault(cate => cate.CategoryId == id);
                if (c == null) return NotFound();
                if (c.Products != null) c.Products.Clear();
                db.Categories.Remove(c);
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }
    }
}
