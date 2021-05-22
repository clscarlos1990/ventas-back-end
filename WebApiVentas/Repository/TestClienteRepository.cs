using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public class TestClienteRepository : ITestClienteRepository
    {
        private readonly DB_VENTASContext _context;

        public TestClienteRepository(DB_VENTASContext context)
        {
            _context = context;
        }
        public async Task<List<TestCliente>> FindAll()
        {
             return await _context.TestClientes.ToListAsync();
        }

        public async Task<TestCliente> FindById(decimal id)
        {
            return await _context.TestClientes.FindAsync(id);
        }
    }
}
