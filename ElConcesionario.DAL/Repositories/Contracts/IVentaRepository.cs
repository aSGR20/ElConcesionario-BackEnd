using ElConcesionario.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.DAL.Repositories.Contracts
{
    public interface IVentaRepository
    {
        void Add(VentaDTO ventaDTO);
        IEnumerable<VentaDTO> Get();
    }
}
