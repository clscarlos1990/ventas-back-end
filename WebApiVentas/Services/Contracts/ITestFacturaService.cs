using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Services.Contracts
{
    public interface ITestFacturaService
    {
        Task<TestFactura> Save(TestFactura testFactura);
    }
}
