using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Models
{
    public partial class TestFacturaDetalle
    {
        public decimal IdFacturaDetalle { get; set; }
        public decimal IdFactura { get; set; }
        public decimal IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnidad { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual TestFactura IdFacturaNavigation { get; set; }
        public virtual TestProducto IdProductoNavigation { get; set; }
    }
}
