using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public class TestFacturaDetalleRepository : ITestFacturaDetalleRepository
    {
        private readonly DB_VENTASContext _context;
        public TestFacturaDetalleRepository(DB_VENTASContext context)
        {
            _context = context;
        }
    }
}
