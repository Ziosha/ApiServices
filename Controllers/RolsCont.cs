using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiService.Data;
using ApiService.Models;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsCont : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolsCont(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RolsCont
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rols>>> GetRols()
        {
            return await _context.Rols.ToListAsync();
        }

        // GET: api/RolsCont/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rols>> GetRols(int id)
        {
            var rols = await _context.Rols.FindAsync(id);

            if (rols == null)
            {
                return NotFound();
            }

            return rols;
        }

        // PUT: api/RolsCont/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRols(int id, Rols rols)
        {
            if (id != rols.Id)
            {
                return BadRequest();
            }

            _context.Entry(rols).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolsExists(id))
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

        // POST: api/RolsCont
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Rols>> PostRols(Rols rols)
        {
            _context.Rols.Add(rols);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRols", new { id = rols.Id }, rols);
        }

        // DELETE: api/RolsCont/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rols>> DeleteRols(int id)
        {
            var rols = await _context.Rols.FindAsync(id);
            if (rols == null)
            {
                return NotFound();
            }

            _context.Rols.Remove(rols);
            await _context.SaveChangesAsync();

            return rols;
        }

        private bool RolsExists(int id)
        {
            return _context.Rols.Any(e => e.Id == id);
        }
    }
}
