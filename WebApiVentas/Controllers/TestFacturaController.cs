using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVentas.Models;
using WebApiVentas.Services.Contracts;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestFacturaController : ControllerBase
    {
        private readonly DB_VENTASContext _context;
        private readonly ITestFacturaService _testFacturaService;

        public TestFacturaController(DB_VENTASContext context, ITestFacturaService testFacturaService)
        {
            _context = context;
            _testFacturaService = testFacturaService;
        }

        // GET: api/TestFactura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestFactura>>> GetTestFacturas()
        {
            return await _context.TestFacturas.ToListAsync();
        }

        // GET: api/TestFactura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestFactura>> GetTestFactura(decimal id)
        {
            var testFactura = await _context.TestFacturas.FindAsync(id);

            if (testFactura == null)
            {
                return NotFound();
            }

            return testFactura;
        }

        // PUT: api/TestFactura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestFactura(decimal id, TestFactura testFactura)
        {
            if (id != testFactura.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(testFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestFacturaExists(id))
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

        // POST: api/TestFactura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestFactura>> PostTestFactura(TestFactura testFactura)
        {
            await _testFacturaService.Save(testFactura);
            //_context.TestFacturas.Add(testFactura);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestFactura", new { id = testFactura.IdFactura }, testFactura);
        }

        // DELETE: api/TestFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestFactura>> DeleteTestFactura(decimal id)
        {
            var testFactura = await _context.TestFacturas.FindAsync(id);
            if (testFactura == null)
            {
                return NotFound();
            }

            _context.TestFacturas.Remove(testFactura);
            await _context.SaveChangesAsync();

            return testFactura;
        }

        private bool TestFacturaExists(decimal id)
        {
            return _context.TestFacturas.Any(e => e.IdFactura == id);
        }
    }
}
