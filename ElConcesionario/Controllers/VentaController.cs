using ElConcesionario.BL.Contracts;
using ElConcesionario.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.Controllers
{
    /*
     * MIRAR VentaRepository.cs
     */
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        public IVentaBL _ventaBL { get; set; }

        public VentaController(IVentaBL ventaBL)
        {
            _ventaBL = ventaBL;
        }

        [HttpPost]
        public ActionResult<bool> Add(VentaDTO ventaDTO)
        {
            _ventaBL.Add(ventaDTO);
            return Ok(true);
        }

        public ActionResult<IEnumerable<VentaDTO>> Get()
        {
            return Ok(_ventaBL.Get());
        }
    }
}
