using ElConcesionario.BL.Contracts;
using System.Collections.Generic;
using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Repositories.Contracts;
using System;

namespace ElConcesionario.BL.Implementations
{
    public class VehiculoBL : IVehiculoBL
    {
        public IVehiculoRepository _vehiculoRepository { get; set; }

        public VehiculoBL(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public void Add(VehiculoDTO vehiculoDTO)
        {
            _vehiculoRepository.Add(vehiculoDTO);
        }

        public IEnumerable<VehiculoDTO> Get()
        {
            var vehiculos = _vehiculoRepository.Get();
            return vehiculos;
        }
    }
}
