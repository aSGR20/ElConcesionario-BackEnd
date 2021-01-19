using ElConcesionario.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.DAL.Repositories.Contracts
{
    public interface IVehiculoRepository
    {
        void Add(VehiculoDTO vehiculoDTO);
        IEnumerable<VehiculoDTO> Get();
    }
}
