using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPi.Models;

namespace WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("master")]
        public IActionResult GetAllMaster()
        {
            using (var db = new PRN292_SU17_1Context())
            {
                var ret = db.DummyMasters.ToList();
                return Ok(ret);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            using (var db = new PRN292_SU17_1Context())
            {
                var ret = db.DummyDetails.Include(c => c.Master).ToList();
                return Ok(ret);
            }
        }


        [HttpGet("list")]
        public IActionResult GetAll(string name)
        {
            using (var db = new PRN292_SU17_1Context())
            {
                var check = db.DummyDetails.Include(c => c.Master).Where(c => c.Master.MasterName.Contains(name)).ToList();
                if (check == null) return NotFound();
                return Ok(check);
            }
        }

        [HttpGet("detail")]
        public IActionResult GetOne(string name)
        {
            using (var db = new PRN292_SU17_1Context())
            {
                var ret = db.DummyDetails.Include(c => c.Master).Where(c => c.DetailName.Contains(name)).ToList();
                if (ret == null) return NotFound();
                return Ok(ret);
            }
        }
    }
}
