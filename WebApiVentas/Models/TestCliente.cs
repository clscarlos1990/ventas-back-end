using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiVentas.Models
{
    public partial class TestCliente
    {
        public TestCliente()
        {
            TestFacturas = new HashSet<TestFactura>();
        }

        public decimal IdCliente { get; set; }
        public decimal Identifiacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TestFactura> TestFacturas { get; set; }
    }
}
