using ElConcesionario.BL.Contracts;
using System.Collections.Generic;
using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Repositories.Contracts;
using System;

namespace ElConcesionario.BL.Implementations
{
    public class VentaBL : IVentaBL
    {
        public IVentaRepository _ventaRepository { get; set; }
        public IVehiculoRepository _vehiculoRepository { get; set; }

        public VentaBL(IVentaRepository ventaRepository, IVehiculoRepository vehiculoRepository)
        {
            _ventaRepository = ventaRepository;
            _vehiculoRepository = vehiculoRepository;
        }

        public void Add(VentaDTO ventaDTO)
        {
            _ventaRepository.Add(ventaDTO);
        }

        public IEnumerable<VentaDTO> Get()
        {
            var ventas = _ventaRepository.Get();
            var vehiculos = _vehiculoRepository.Get();
            var numSeries = new List<int>();
            List<VentaDTO> ventasFinales = new List<VentaDTO>();

            foreach (var v in ventas)
            {
                foreach (var u in vehiculos)
                {
                    if (v.NumSerie == u.NumSerie)
                    {
                        v.Marca = u.Marca;
                        v.Modelo = u.Modelo;
                        v.Precio = u.Precio;
                        v.Tipo = u.Tipo;
                    }
                }
            }
            return ventas;
        }
    }
}
