using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webtemp_api.Models;

namespace webtemp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuInfoesController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly Interface _add;

        public StuInfoesController(SchoolContext context, Interface add)
        {
            _context = context;
            _add = add;
        }

        // GET: api/StuInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StuInfo>>> GetStuInfos()
        {
            Console.WriteLine($"{await _add.Num()}");
            return await _context.StuInfos.ToListAsync();
        }

        // GET: api/StuInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StuInfo>> GetStuInfo(int id)
        {
            var stuInfo = await _context.StuInfos.FindAsync(id);

            if (stuInfo == null)
            {
                return NotFound();
            }

            Console.WriteLine(stuInfo.Stuid);

            return stuInfo;
        }

        // PUT: api/StuInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStuInfo(int id, StuInfo stuInfo)
        {
            if (id != stuInfo.Stuid)
            {
                return BadRequest();
            }

            _context.Entry(stuInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StuInfoExists(id))
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

        // POST: api/StuInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StuInfo>> PostStuInfo(StuInfo stuInfo)
        {
            _context.StuInfos.Add(stuInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStuInfo", new { id = stuInfo.Stuid }, stuInfo);
        }

        // DELETE: api/StuInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuInfo(int id)
        {
            var stuInfo = await _context.StuInfos.FindAsync(id);
            if (stuInfo == null)
            {
                return NotFound();
            }

            _context.StuInfos.Remove(stuInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StuInfoExists(int id)
        {
            return _context.StuInfos.Any(e => e.Stuid == id);
        }
    }
}
