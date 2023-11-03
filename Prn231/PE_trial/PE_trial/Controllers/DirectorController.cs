using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using PE_trial.Models;
using PE_trial.ModelsDTO;

namespace PE_trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {

        private readonly PE_PRN_Fall22B1Context _context;

        public DirectorController(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }

        [HttpGet("GetDirectors/{nationality}/{gender}")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors(string nationality, string gender)
        {
            if (_context.Directors == null)
            {
                return NotFound();
            }

            var list = await _context.Directors
                .Where(c => c.Nationality.ToLower() == nationality)
                .Select(d => new Director
                {
                    Id = d.Id,
                    FullName = d.FullName,
                    Male = d.Male,
                    Dob = d.Dob,
                    Nationality = d.Nationality,
                    Description = d.Description,
                    Movies = null,
                })
                .ToListAsync();

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }


        [HttpGet("GetDirectors/{id}")]
        [EnableQuery]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            if (_context.Directors == null)
            {
                return NotFound();
            }
            var direct = await _context.Directors.Include(c => c.Movies).SingleOrDefaultAsync(c => c.Id == id);
            if (direct == null) return NotFound();
            return direct;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<string>> Post(DirectorA3 director)
        {
            if (_context.Directors == null)
            {
                return Problem("Entity set 'MyStoreContext.Questions'  is null.");
            }
            try
            {

                _context.Directors.Add(new Director
                {
                    FullName = director.FullName,
                    Male = director.Male,
                    Dob = director.Dob,
                    Nationality = director.Nationality,
                    Description = director.Description
                });
                await _context.SaveChangesAsync();
                return Ok("1");
            }
            catch (Exception)
            {
                return Problem("There is an error while adding");
            }
        }

    }
}
