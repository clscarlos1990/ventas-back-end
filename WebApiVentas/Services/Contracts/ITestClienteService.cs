using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Services.Contracts
{
    public interface ITestClienteService
    {
        Task<List<TestCliente>> FindAll();

        Task<TestCliente> FindById(decimal id);

    }
}
