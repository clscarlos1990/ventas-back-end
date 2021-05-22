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
    public class TestClienteService : ITestClienteService
    {
        private ITestClienteRepository _testClienteRepository;

        public TestClienteService(ITestClienteRepository testClienteRepository)
        {
            _testClienteRepository = testClienteRepository;
        }
        public async Task<List<TestCliente>> FindAll()
        {
             return await _testClienteRepository.FindAll();
        }

        public async Task<TestCliente> FindById(decimal id)
        {
            return await _testClienteRepository.FindById(id);
        }
    }
}
