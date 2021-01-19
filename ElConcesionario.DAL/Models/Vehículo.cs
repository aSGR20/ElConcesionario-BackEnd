using System;
using System.Collections.Generic;

namespace ElConcesionario.DAL.Models
{
    public partial class Vehículo
    {
        public Vehículo()
        {
            Venta = new HashSet<Venta>();
        }

        public int NumSerial { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public string FechaEntrada { get; set; }
        public int Anyo { get; set; }
        public int Kilometros { get; set; }
        public string Combustible { get; set; }
        public string InfAdicional { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
