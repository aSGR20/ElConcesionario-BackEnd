using ElConcesionario.Core.DTO;
using System;
using System.Collections.Generic;

namespace ElConcesionario.BL.Contracts
{
    public interface IVentaBL
    {
        void Add(VentaDTO ventaDTO);
        IEnumerable<VentaDTO> Get();
    }
}
