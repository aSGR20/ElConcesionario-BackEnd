using System;
using System.Collections.Generic;

namespace ElConcesionario.DAL.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reparación = new HashSet<Reparación>();
            Venta = new HashSet<Venta>();
        }

        public string DniUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nuss { get; set; }
        public int SueldoBase { get; set; }
        public string Correo { get; set; }
        public string Profesión { get; set; }

        public virtual Mecánico Mecánico { get; set; }
        public virtual ICollection<Reparación> Reparación { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
