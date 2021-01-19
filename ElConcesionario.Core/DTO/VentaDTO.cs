using System;

namespace ElConcesionario.Core.DTO
{
    public class VentaDTO
    {
        public int NumSerie { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public string Plazo { get; set; }
        public string Fecha { get; set; }

        public VentaDTO()
        {
        }
    }
}
