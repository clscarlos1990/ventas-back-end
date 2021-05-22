using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public interface ITestClienteRepository
    {
        Task<List<TestCliente>> FindAll();

        Task<TestCliente> FindById(decimal id);

    }
}
