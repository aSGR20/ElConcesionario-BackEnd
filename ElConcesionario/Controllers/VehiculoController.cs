using ElConcesionario.BL.Contracts;
using ElConcesionario.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiculoController : ControllerBase
    {
        public IVehiculoBL _vehiculoBL { get; set; }

        protected VehiculoController (IVehiculoBL vehiculoBL)
        {
            _vehiculoBL = vehiculoBL;
        }

        [HttpPost]
        protected ActionResult<bool> Add(VehiculoDTO vehiculoDTO)
        {
            _vehiculoBL.Add(vehiculoDTO);
            return Ok(true);
        }

        protected ActionResult<IEnumerable<VehiculoDTO>> Get()
        {
            return Ok(_vehiculoBL.Get());
        }
    }
}
