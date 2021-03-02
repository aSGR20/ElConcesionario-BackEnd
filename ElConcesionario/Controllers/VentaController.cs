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
    public class VentaController : ControllerBase
    {
        public IVentaBL _ventaBL { get; set; }

        protected VentaController(IVentaBL ventaBL)
        {
            _ventaBL = ventaBL;
        }

        [HttpPost]
        protected ActionResult<bool> Add(VentaDTO ventaDTO)
        {
            _ventaBL.Add(ventaDTO);
            return Ok(true);
        }

        protected ActionResult<IEnumerable<VentaDTO>> Get()
        {
            return Ok(_ventaBL.Get());
        }
    }
}
