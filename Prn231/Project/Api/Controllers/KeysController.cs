using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.AspNetCore.OData.Query;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly MyStoreContext _context;

        public KeysController(MyStoreContext context)
        {
            _context = context;
        }

        // GET: api/Keys
        [HttpGet]
        [EnableQuery]

        public async Task<ActionResult<IEnumerable<Key>>> GetKeys()
        {
          if (_context.Keys == null)
          {
              return NotFound();
          }
            return await _context.Keys.ToListAsync();
        }


        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<string>> GetKey(string key)
        {
            var ret = await _context.Keys.Include(c =>c.Course)
                .SingleOrDefaultAsync(c => c.KeyId == key);
            if (ret == null) return NotFound();
            return Ok(ret.Course.CourseName);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(KeyDTO key)
        {
            if (!_context.Courses.Any(c => c.CourseId == key.CourseId) || _context.Keys.Any(c => c.KeyId == key.KeyId))
                return Problem();
            Key input = new Key
            {
                KeyId = key.KeyId,
                CourseId = key.CourseId,
            };
            foreach (QuestionDTO ques in key.Questions)
            {
                Question que = new Question
                {
                    QuestionId = ques.QuestionId,
                    KeyId = ques.KeyId,
                    Content = ques.Content,
                    Answer = ques.Answer,
                    RightAnswer = ques.RightAnswer,
                };
                input.Questions.Add(que);
            }

            _context.Keys.Add(input);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool KeyExists(string id)
        {
            return (_context.Keys?.Any(e => e.KeyId == id)).GetValueOrDefault();
        }
    }
}
