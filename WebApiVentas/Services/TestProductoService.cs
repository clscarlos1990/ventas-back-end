using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;
using WebApiVentas.Repository;
using WebApiVentas.Services.Contracts;

namespace WebApiVentas.Services
{
    public class TestProductoService : ITestProductoService
    {
        private ITestProductoRepository _testProductoRepository;

        public TestProductoService(ITestProductoRepository testProductoRepository)
        {
            _testProductoRepository = testProductoRepository;
        }
        public async Task<List<TestProducto>> FindAll()
        {
            return await _testProductoRepository.FindAll();
        }
        public async Task<TestProducto> FindById(decimal id)
        {
            return await _testProductoRepository.FindById(id);
        }

    }
}
