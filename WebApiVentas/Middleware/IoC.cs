using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVentas.Repository;
using WebApiVentas.Services;
using WebApiVentas.Services.Contracts;

namespace WebApiVentas.Middleware
{
    public static class IoC
    {
        public static IServiceCollection serviceDescriptors(this IServiceCollection services)
        {
            services.AddTransient<ITestClienteRepository, TestClienteRepository> ();
            services.AddTransient<ITestProductoRepository, TestProductoRepository> ();
            services.AddTransient<ITestFacturaRepository, TestFacturaRepository>();
            services.AddTransient<ITestFacturaDetalleRepository, TestFacturaDetalleRepository>();

            services.AddTransient<ITestClienteService, TestClienteService>();
            services.AddTransient<ITestProductoService, TestProductoService>();
            services.AddTransient<ITestFacturaService, TestFacturaService>();
            services.AddTransient<ITestFacturaDetalleService, TestFacturaDetalleService>();

            return services;
        }
    }
}
