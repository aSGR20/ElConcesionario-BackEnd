using System;
using ElConcesionario.BL.Contracts;
using ElConcesionario.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ElConcesionario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        public IUsuarioBL _usuarioBL { get; set; }

        public LoginController(IUsuarioBL usuarioBL)
        {

            _usuarioBL = usuarioBL;
        }

        [HttpPost]
        public bool Login(UsuarioDTO usuarioDTO)
        {
           return _usuarioBL.Login(usuarioDTO);
        }
    }
}
