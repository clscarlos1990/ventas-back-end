using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Models
{
    public partial class TestProducto
    {
        public TestProducto()
        {
            TestFacturaDetalles = new HashSet<TestFacturaDetalle>();
        }

        public decimal IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnidad { get; set; }
        public int Stock { get; set; }

        public virtual ICollection<TestFacturaDetalle> TestFacturaDetalles { get; set; }
    }
}
