using ElConcesionario.Core.DTO;
using System;
using System.Collections.Generic;

namespace ElConcesionario.BL.Contracts
{
    public interface IVehiculoBL
    {
        void Add(VehiculoDTO vehiculoDTO);
        IEnumerable<VehiculoDTO> Get();
    }
}
