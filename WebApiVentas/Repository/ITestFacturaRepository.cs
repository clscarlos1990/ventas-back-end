using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public interface ITestFacturaRepository
    {
        Task<List<TestFactura>> FindAll();
        Task<TestFactura> FindById(decimal id);
        Task<TestFactura> Save(TestFactura testFactura);
    }
}
