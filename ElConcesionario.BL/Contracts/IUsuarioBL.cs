using ElConcesionario.Core.DTO;
using System;
using System.Collections.Generic;

namespace ElConcesionario.BL.Contracts
{
    public interface IUsuarioBL
    {
        bool Login(UsuarioDTO usuarioDTO);
        void Add(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> Get();
    }
}
