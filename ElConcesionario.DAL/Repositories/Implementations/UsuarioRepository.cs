using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Models;
using ElConcesionario.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.DAL.Repositories.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public desarrollodeinterfacesContext _context { get; set; }

        public UsuarioRepository(desarrollodeinterfacesContext context)
        {
            _context = context;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _context.Usuario.Any(u => u.Usuario1 == usuarioDTO.Username &&
           u.Contraseña == usuarioDTO.Password && u.Profesión == "Jefe");
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Usuario1 = usuarioDTO.Username,
                Contraseña = usuarioDTO.Password,
                Correo = usuarioDTO.Email,
                Nombre = usuarioDTO.Name,
                Apellidos = usuarioDTO.Apellidos,
                Profesión = usuarioDTO.Rol
            };
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _context.Usuario.ToList();

            //Mapeo de Usuario a UsuarioDTO
            List<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            foreach(var i in usuarios)
            {
                var usuario = new UsuarioDTO
                {
                    Username = i.Usuario1,
                    Password = i.Contraseña,
                    Email = i.Correo,
                    Name = i.Nombre,
                    Apellidos = i.Apellidos,
                    Rol = i.Profesión
                };
                usuariosDTO.Add(usuario);
            }
            return usuariosDTO;
        }
    }
}
