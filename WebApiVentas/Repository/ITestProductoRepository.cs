using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Models;

namespace WebApiVentas.Repository
{
    public interface ITestProductoRepository
    {
        Task<List<TestProducto>> FindAll();

        Task<TestProducto> FindById(decimal id);

    }
}
