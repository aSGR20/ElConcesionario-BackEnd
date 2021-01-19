using ElConcesionario.BL.Contracts;
using System.Collections.Generic;
using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Repositories.Contracts;
using System;

namespace ElConcesionario.BL.Implementations
{
    public class UsuarioBL : IUsuarioBL
    {
        public IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioBL(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Login(UsuarioDTO usuarioDTO)
        {
            return _usuarioRepository.Login(usuarioDTO);
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Add(usuarioDTO);
        }

        public IEnumerable<UsuarioDTO> Get()
        {
            var usuarios = _usuarioRepository.Get();
            return usuarios;
        }
    }
}
