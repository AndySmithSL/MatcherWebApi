using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatcherWebApi.Models;
using MatcherWebApi.Interfaces;
using MatcherWebApi.Classes;

namespace MatcherWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly MatcherContext context;

        private IMatcher matcher = null;

        public IMatcher Matcher
        {
            get => matcher;
            set => matcher = value;
        }

        public MatcherContext Context => context;

        public AccountsController(MatcherContext dbContext)
        {
            context = dbContext;
            Matcher = new Matcher(Context);
        }

        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<IAccount> GetAccounts()
        {
            return Matcher.AccountManager.Accounts;
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await Context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount([FromRoute] int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.AccountId)
            {
                return BadRequest();
            }

            Context.Entry(account).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Context.Accounts.Add(account);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await Context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            Context.Accounts.Remove(account);
            await Context.SaveChangesAsync();

            return Ok(account);
        }

        private bool AccountExists(int id)
        {
            return Context.Accounts.Any(e => e.AccountId == id);
        }
    }
}