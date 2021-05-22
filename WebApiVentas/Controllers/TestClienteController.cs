using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiVentas.Models;
using WebApiVentas.Services;
using WebApiVentas.Services.Contracts;

namespace WebApiVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestClienteController : ControllerBase
    {
        private readonly DB_VENTASContext _context;
        private readonly ITestClienteService _testClienteService;

        public TestClienteController(DB_VENTASContext context, ITestClienteService testClienteService)
        {
            _context = context;
            _testClienteService = testClienteService;
        }

        // GET: api/TestCliente
        [HttpGet]
        public async Task<ActionResult<List<TestCliente>>> GetTestClientes()
        {
            return await _testClienteService.FindAll();
        }

        // GET: api/TestCliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestCliente>> GetTestCliente(decimal id)
        {
            var testCliente = await _testClienteService.FindById(id);

            if (testCliente == null)
            {
                return NotFound();
            }

            return testCliente;
        }

        // PUT: api/TestCliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestCliente(decimal id, TestCliente testCliente)
        {
            if (id != testCliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(testCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestClienteExists(id))
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

        // POST: api/TestCliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TestCliente>> PostTestCliente(TestCliente testCliente)
        {
            _context.TestClientes.Add(testCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestCliente", new { id = testCliente.IdCliente }, testCliente);
        }

        // DELETE: api/TestCliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestCliente>> DeleteTestCliente(decimal id)
        {
            var testCliente = await _context.TestClientes.FindAsync(id);
            if (testCliente == null)
            {
                return NotFound();
            }

            _context.TestClientes.Remove(testCliente);
            await _context.SaveChangesAsync();

            return testCliente;
        }

        private bool TestClienteExists(decimal id)
        {
            return _context.TestClientes.Any(e => e.IdCliente == id);
        }
    }
}
