using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.AspNetCore.OData.Query;
using NuGet.Packaging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly MyStoreContext _context;

        public QuestionsController(MyStoreContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions()
        {
            if (_context.Questions == null)
            {
                return NotFound();
            }
            var list = await _context.Questions.ToListAsync();
            var ret = new List<QuestionDTO>();
            foreach (Question item in list)
            {
                var question = new QuestionDTO()
                {
                    QuestionId = item.QuestionId,
                    KeyId = item.KeyId,
                    Content = item.Content,
                    Answer = item.Answer,
                    NumberRightAnswer = item.RightAnswer.Split('/').Length,
                };
                ret.Add(question);
            }
            return ret;
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult> GetExams(string key)
        {
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var list = await _context.Exams.Where(c => c.KeyId == key).Include(c => c.Account).Include(e => e.Key)
                .Select(c => new
                {
                    AccountName = c.Account.FullName,
                    ExamId = c.ExamId,
                    Score = c.Score,
                }).ToListAsync();
            return Ok(list);
        }

        [HttpGet("gen/{key}")]
        [EnableQuery]
        public async Task<ActionResult> GetExamsGen(string key)
        {
            if (_context.Exams == null)
            {
                return NotFound();
            }
            var list = await _context.Exams.Where(c => c.KeyId == key).Include(c => c.Account)
                .Select(c => new
                {
                    AccountId = c.AccountId,
                    AccountName = c.Account.FullName,
                    KeyId = c.KeyId,
                    Score = c.Score,
                    ExamAnswers = c.ExamAnswers,
                }).ToListAsync();
            return Ok(list);
        }


        [HttpPost]
        public async Task<ActionResult<Question>> PostExam(ExamSubmit exam)
        {
            if (!_context.Accounts.Any(c => c.AccountId == exam.AccountId) || !_context.Keys.Any(c => c.KeyId == exam.KeyId))
                return Problem();
            var right = await _context.Questions.Where(c => c.KeyId == exam.KeyId).Select(c => c.RightAnswer).ToListAsync();
            var index = 0;
            var total = 0;

            Exam submit = new Exam()
            {
                AccountId = exam.AccountId,
                KeyId = exam.KeyId,
                Score = exam.Score,
            };

            foreach (ExamAnswerDTO item in exam.ExamAnswers)
            {
                //ExamAnswer answer = new ExamAnswer()
                //{
                //    ExamAnswer1 = item.ExamAnswer1,
                //    ExamId = item.ExamId,
                //    RightRightAnswer = item.RightRightAnswer,
                //};

                if (item.RightRightAnswer == right[index]) total++;
                index++;
            }
            double ratio = (double)total / right.Count * 10;
            submit.Score = ratio.ToString("0.00");
            _context.Exams.Add(submit);
            await _context.SaveChangesAsync();
            return Ok();
            //return CreatedAtAction("GetQuestion", new { id = exam.ExamId }, exam);
        }




        // GET: api/Questions/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Question>> GetQuestion(int id)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return NotFound();
        //    }
        //    var question = await _context.Questions.FindAsync(id);

        //    if (question == null)
        //    {
        //        return NotFound();
        //    }

        //    return question;
        //}

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutQuestion(int id, Question question)
        //{
        //    if (id != question.QuestionId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(question).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!QuestionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Question>> PostQuestion(Question question)
        //{
        //    if (_context.Questions == null)
        //    {
        //        return Problem("Entity set 'MyStoreContext.Questions'  is null.");
        //    }
        //    _context.Questions.Add(question);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        //}

        [HttpDelete("{examid}")]
        public async Task<IActionResult> DeleteQuestion(int examid)
        {
            if (_context.Exams == null) return NotFound();
            var exam = await _context.Exams.
                Include(c => c.ExamAnswers).Include(c => c.Key)
                .SingleOrDefaultAsync(c => c.ExamId == examid);

            if (exam == null) return NotFound();

            exam.ExamAnswers.Clear();
            //exam.Key.Clear();
            //exam.Key.Clear();
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}
