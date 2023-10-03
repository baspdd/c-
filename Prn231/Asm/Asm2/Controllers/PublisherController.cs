using Asm2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asm2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                return Ok(db.Publishers.ToList());
            }
        }

        [HttpPost]
        public IActionResult Add(Publisher author)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                db.Publishers.Add(author);
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult Update(Publisher author)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                db.Publishers.Update(author);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                var or = db.Publishers.SingleOrDefault(o => o.PubId == id);
                if (or == null) return NotFound();
                db.Publishers.Remove(or);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
