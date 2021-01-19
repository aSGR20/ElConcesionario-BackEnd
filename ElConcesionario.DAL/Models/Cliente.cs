using System;
using System.Collections.Generic;

namespace ElConcesionario.DAL.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reparación = new HashSet<Reparación>();
            Venta = new HashSet<Venta>();
        }

        public string DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Teléfono { get; set; }
        public string Domicilio { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Reparación> Reparación { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
