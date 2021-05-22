using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;
using WebApiVentas.Repository;
using WebApiVentas.Services.Contracts;

namespace WebApiVentas.Services
{
    public class TestFacturaService : ITestFacturaService
    {
        private ITestFacturaRepository _testFacturaRespository;
        private ITestProductoRepository _testProductoRepository;

        public TestFacturaService(ITestFacturaRepository facturaRepository, ITestProductoRepository testProductoRepository)
        {
            _testFacturaRespository = facturaRepository;
            _testProductoRepository = testProductoRepository;
        }
        public async Task<TestFactura> Save(TestFactura testFactura)
        {
            await _testFacturaRespository.Save(testFactura);
            if(testFactura.IdFactura != 0)
            {

            }
            return testFactura;
        }
    }
}
