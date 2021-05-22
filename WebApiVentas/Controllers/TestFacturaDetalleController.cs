using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVentas.Models;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestFacturaDetalleController : ControllerBase
    {
        private readonly DB_VENTASContext _context;

        public TestFacturaDetalleController(DB_VENTASContext context)
        {
            _context = context;
        }

        // GET: api/TestFacturaDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFacturaDetalle>>> GetTestFacturaDetalles()
        {
            return await _context.TestFacturaDetalles.ToListAsync();
        }

        // GET: api/TestFacturaDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestFacturaDetalle>> GetTestFacturaDetalle(decimal id)
        {
            var testFacturaDetalle = await _context.TestFacturaDetalles.FindAsync(id);

            if (testFacturaDetalle == null)
            {
                return NotFound();
            }

            return testFacturaDetalle;
        }

        // PUT: api/TestFacturaDetalle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestFacturaDetalle(decimal id, TestFacturaDetalle testFacturaDetalle)
        {
            if (id != testFacturaDetalle.IdFacturaDetalle)
            {
                return BadRequest();
            }

            _context.Entry(testFacturaDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestFacturaDetalleExists(id))
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

        // POST: api/TestFacturaDetalle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestFacturaDetalle>> PostTestFacturaDetalle(TestFacturaDetalle testFacturaDetalle)
        {
            _context.TestFacturaDetalles.Add(testFacturaDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestFacturaDetalle", new { id = testFacturaDetalle.IdFacturaDetalle }, testFacturaDetalle);
        }

        // DELETE: api/TestFacturaDetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestFacturaDetalle>> DeleteTestFacturaDetalle(decimal id)
        {
            var testFacturaDetalle = await _context.TestFacturaDetalles.FindAsync(id);
            if (testFacturaDetalle == null)
            {
                return NotFound();
            }

            _context.TestFacturaDetalles.Remove(testFacturaDetalle);
            await _context.SaveChangesAsync();

            return testFacturaDetalle;
        }

        private bool TestFacturaDetalleExists(decimal id)
        {
            return _context.TestFacturaDetalles.Any(e => e.IdFacturaDetalle == id);
        }
    }
}
