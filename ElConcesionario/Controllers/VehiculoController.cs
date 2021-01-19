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

        public VehiculoController (IVehiculoBL vehiculoBL)
        {
            _vehiculoBL = vehiculoBL;
        }

        [HttpPost]
        public ActionResult<bool> Add(VehiculoDTO vehiculoDTO)
        {
            _vehiculoBL.Add(vehiculoDTO);
            return Ok(true);
        }

        public ActionResult<IEnumerable<VehiculoDTO>> Get()
        {
            return Ok(_vehiculoBL.Get());
        }
    }
}
