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
            using (MyStoreContext db = new MyStoreContext())
            {
                return Ok(db.Categories.ToList());
            }
        }
        //Get:api/Category/id
        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            using (MyStoreContext db = new MyStoreContext())
            {
                var cate = db.Categories.SingleOrDefault(cate => cate.CategoryId == id);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }

        //Post:api/Category
        [HttpPost]
        public IActionResult AddCategory(string name)
        {
            using (MyStoreContext db = new MyStoreContext())
            {
                Category cate = new Category();
                cate.CategoryName = name;
                db.Categories.Add(cate);
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(int id , string name)
        {
            using (MyStoreContext db = new MyStoreContext())
            {
                var c = db.Categories.SingleOrDefault(cate => cate.CategoryId == id);
                if (c == null) return NotFound();
                c.CategoryName = name;
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using (MyStoreContext db = new MyStoreContext())
            {
                var c = db.Categories.Include(c =>c.Products).SingleOrDefault(cate => cate.CategoryId == id);
                if (c == null) return NotFound();
                if (c.Products != null) return BadRequest();
                db.Categories.Remove(c);
                db.SaveChanges();
                return Ok(db.Categories.ToList());
            }
        }
    }
}
