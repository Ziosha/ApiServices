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
    public class RolsUsCont : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolsUsCont(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RolsUsCont
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolsUser>>> GetRolsUsers()
        {
            return await _context.RolsUsers.ToListAsync();
        }

        // GET: api/RolsUsCont/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolsUser>> GetRolsUser(int id)
        {
            var rolsUser = await _context.RolsUsers.FindAsync(id);

            if (rolsUser == null)
            {
                return NotFound();
            }

            return rolsUser;
        }

        // PUT: api/RolsUsCont/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolsUser(int id, RolsUser rolsUser)
        {
            if (id != rolsUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(rolsUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolsUserExists(id))
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

        // POST: api/RolsUsCont
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RolsUser>> PostRolsUser(RolsUser rolsUser)
        {
            _context.RolsUsers.Add(rolsUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolsUser", new { id = rolsUser.Id }, rolsUser);
        }

        // DELETE: api/RolsUsCont/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolsUser>> DeleteRolsUser(int id)
        {
            var rolsUser = await _context.RolsUsers.FindAsync(id);
            if (rolsUser == null)
            {
                return NotFound();
            }

            _context.RolsUsers.Remove(rolsUser);
            await _context.SaveChangesAsync();

            return rolsUser;
        }

        private bool RolsUserExists(int id)
        {
            return _context.RolsUsers.Any(e => e.Id == id);
        }
    }
}
