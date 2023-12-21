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
    public class AccountsController : ControllerBase
    {
        private readonly MyStoreContext _context;

        public AccountsController(MyStoreContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<int>> GetAccount(string acc, string pass, string key)
        {
            if (_context.Accounts == null || _context.Keys == null)
            {
                return NotFound();
            }
            if (!_context.Keys.Any(c => c.KeyId == key)) return 1;
            if (!_context.Accounts.Any(c => c.AccountId == acc && c.Password == pass)) return 2;
            if (_context.Exams.Any(c => c.AccountId == acc && c.KeyId == key)) return 3;
            return 4;
        }


        [HttpGet("Staff")]
        [EnableQuery]
        public async Task<ActionResult> GetAccountStaff(string acc, string pass)
        {
            if (_context.Accounts == null)
                return NotFound();
            if (_context.Accounts.Any(c => c.AccountId == acc && c.Password == pass && c.Type == 0)) return Ok(0);
            return Ok(1);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(string id)
        {
            if (_context.Accounts == null) return NotFound();
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return NotFound();
            return new AccountDTO() { AccountId = account.AccountId, FullName = account.FullName };
        }

        //// PUT: api/Accounts/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAccount(string id, Account account)
        //{
        //    if (id != account.AccountId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(account).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AccountExists(id))
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

        //// POST: api/Accounts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Account>> PostAccount(Account account)
        //{
        //    if (_context.Accounts == null)
        //    {
        //        return Problem("Entity set 'MyStoreContext.Accounts'  is null.");
        //    }
        //    _context.Accounts.Add(account);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AccountExists(account.AccountId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        //}

        //// DELETE: api/Accounts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccount(string id)
        //{
        //    if (_context.Accounts == null)
        //    {
        //        return NotFound();
        //    }
        //    var account = await _context.Accounts.FindAsync(id);
        //    if (account == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Accounts.Remove(account);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool AccountExists(string id)
        {
            return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
