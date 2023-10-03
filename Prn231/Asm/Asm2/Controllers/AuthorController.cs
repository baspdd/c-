using Asm2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asm2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                return Ok(db.Authors.ToList());
            }
        }

        [HttpPost]
        public IActionResult Insert(Author author)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult Update(Author author)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                db.Authors.Update(author);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                var or = db.Authors.SingleOrDefault(o => o.AuthorId == id);
                if (or == null) return NotFound();
                db.Authors.Remove(or);
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
