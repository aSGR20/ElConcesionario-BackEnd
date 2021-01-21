using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Models;
using ElConcesionario.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.DAL.Repositories.Implementations
{
    public class VentaRepository : IVentaRepository
    {
        public desarrollodeinterfacesContext _context { get; set; }

        public VentaRepository(desarrollodeinterfacesContext context)
        {
            _context = context;
        }

        public void Add(VentaDTO ventaDTO)
        {
            var venta = new Venta
            {
                // MODIFICAR ESTO CON LA CLAVE FORÁNEA
                NumSerial = ventaDTO.NumSerie,
                DniCliente = ventaDTO.DNICliente,
                DniUsuario = ventaDTO.DNIUsuario,
                Beneficios = ventaDTO.Beneficios,
                Plazo = ventaDTO.Plazo,
                Fecha = ventaDTO.Fecha
            };
            _context.Venta.Add(venta);
            _context.SaveChanges();
        }

        public IEnumerable<VentaDTO> Get()
        {
            var ventas = _context.Venta.ToList();

            //Mapeo de Venta a VentaDTO
            List<VentaDTO> ventasDTO = new List<VentaDTO>();
            foreach (var i in ventas)
            {
                var venta = new VentaDTO
                {
                    // MODIFICAR ESTO CON LA CLAVE FORÁNEA
                    NumSerie = i.NumSerial,
                    DNICliente = i.DniCliente,
                    DNIUsuario = i.DniUsuario,
                    Beneficios = i.Beneficios,
                    Plazo = i.Plazo,
                    Fecha = i.Fecha
                };
                ventasDTO.Add(venta);
            }
            return ventasDTO;
        }
    }
}
