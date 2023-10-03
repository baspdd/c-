using Asm2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asm2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                return Ok(db.Users.ToList());
            }
        }
        [HttpGet("user")]
        public IActionResult GetUser(string email, string password)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                var cate = db.Users.SingleOrDefault(cate => cate.Email == email && cate.Password == password);
                if (cate == null) return NotFound();
                return Ok(cate);
            }
        }


        [HttpPost]
        public IActionResult Insert(User user)
        {
            using (MySaleDbContext db = new MySaleDbContext())
            {
                var check = db.Users.Any(cate => cate.Email == user.Email);
                if (check) return BadRequest();
                db.Users.Add(user);
                db.SaveChanges();
                return Ok();
            }
        }

    }
}
