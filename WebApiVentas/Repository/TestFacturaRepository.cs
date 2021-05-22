using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public class TestFacturaRepository : ITestFacturaRepository
    {
        private readonly DB_VENTASContext _context;
        public TestFacturaRepository(DB_VENTASContext context)
        {
            _context = context;
        }
        public async Task<List<TestFactura>> FindAll()
        {
            return await _context.TestFacturas.ToListAsync();
        }

        public async Task<TestFactura> FindById(decimal id)
        {
            return await _context.TestFacturas.FindAsync(id);
        }

        public async Task<TestFactura> Save(TestFactura testFactura)
        {
            _context.TestFacturas.Add(testFactura);
            await _context.SaveChangesAsync();
            return testFactura;
        }
    }
}
