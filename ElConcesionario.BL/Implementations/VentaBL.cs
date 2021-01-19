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

        public VentaBL(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public void Add(VentaDTO ventaDTO)
        {
            _ventaRepository.Add(ventaDTO);
        }

        public IEnumerable<VentaDTO> Get()
        {
            var ventas = _ventaRepository.Get();
            return ventas;
        }
    }
}
