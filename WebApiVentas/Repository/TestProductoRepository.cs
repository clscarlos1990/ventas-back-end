using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public class TestProductoRepository : ITestProductoRepository
    {
        private readonly DB_VENTASContext _context;

        public TestProductoRepository(DB_VENTASContext context)
        {
            _context = context;
        }
        public async Task<List<TestProducto>> FindAll()
        {
            return await _context.TestProductos.ToListAsync();
        }
        public async Task<TestProducto> FindById(decimal id)
        {
            return await _context.TestProductos.FindAsync(id);
        }

    }
}
