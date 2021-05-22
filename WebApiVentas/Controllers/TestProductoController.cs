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
    public class TestProductoController : ControllerBase
    {
        private readonly DB_VENTASContext _context;
        private readonly ITestProductoService _testProductoService;

        public TestProductoController(DB_VENTASContext context, ITestProductoService testProductoService)
        {
            _context = context;
            _testProductoService = testProductoService;
        }

        // GET: api/TestProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestProducto>>> GetTestProductos()
        {
            return await _context.TestProductos.ToListAsync();
        }

        // GET: api/TestProducto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestProducto>> GetTestProducto(decimal id)
        {
            var testProducto = await _context.TestProductos.FindAsync(id);

            if (testProducto == null)
            {
                return NotFound();
            }

            return testProducto;
        }

        // PUT: api/TestProducto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestProducto(decimal id, TestProducto testProducto)
        {
            if (id != testProducto.IdProducto)
            {
                return BadRequest();
            }

            _context.Entry(testProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestProductoExists(id))
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

        // POST: api/TestProducto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestProducto>> PostTestProducto(TestProducto testProducto)
        {
            _context.TestProductos.Add(testProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestProducto", new { id = testProducto.IdProducto }, testProducto);
        }

        // DELETE: api/TestProducto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestProducto>> DeleteTestProducto(decimal id)
        {
            var testProducto = await _context.TestProductos.FindAsync(id);
            if (testProducto == null)
            {
                return NotFound();
            }

            _context.TestProductos.Remove(testProducto);
            await _context.SaveChangesAsync();

            return testProducto;
        }

        private bool TestProductoExists(decimal id)
        {
            return _context.TestProductos.Any(e => e.IdProducto == id);
        }
    }
}
