using System;

namespace ElConcesionario.Core.DTO
{
    public class VehiculoDTO
    {
        public int NumSerie { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int Precio { get; set; }
        public string FechaEntrada { get; set; }
        public string InfAdicional { get; set; }

        public VehiculoDTO()
        {
        }
    }
}
