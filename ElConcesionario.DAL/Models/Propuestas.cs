using System;
using System.Collections.Generic;

namespace ElConcesionario.DAL.Models
{
    public partial class Propuestas
    {
        public string DniCliente { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string FechaEntrada { get; set; }
    }
}
