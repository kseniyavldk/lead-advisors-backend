﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeadAdvisorsBackend.Data;
using LeadAdvisorsBackend.Models;

namespace LeadAdvisorsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly LeadAdvisorsBackendContext _context;

        public EmailController(LeadAdvisorsBackendContext context)
        {
            _context = context;
        }

        // GET: api/Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmail()
        {
            return await _context.Email.ToListAsync();
        }

        // GET: api/Email/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _context.Email.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Email/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Email
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Email.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.Id }, email);
        }

        // DELETE: api/Email/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Email>> DeleteEmail(int id)
        {
            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Email.Remove(email);
            await _context.SaveChangesAsync();

            return email;
        }

        private bool EmailExists(int id)
        {
            return _context.Email.Any(e => e.Id == id);
        }
    }
}
