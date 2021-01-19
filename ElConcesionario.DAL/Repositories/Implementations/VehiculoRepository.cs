using ElConcesionario.Core.DTO;
using ElConcesionario.DAL.Models;
using ElConcesionario.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElConcesionario.DAL.Repositories.Implementations
{
    public class VehiculoRepository : IVehiculoRepository
    {
        public desarrollodeinterfacesContext _context { get; set; }

        public VehiculoRepository(desarrollodeinterfacesContext context)
        {
            _context = context;
        }

        public void Add(VehiculoDTO vehiculoDTO)
        {
            var vehiculo = new Vehículo
            {
                NumSerial = vehiculoDTO.NumSerie,
                Modelo = vehiculoDTO.Modelo,
                Marca = vehiculoDTO.Marca,
                Tipo = vehiculoDTO.Tipo,
                Precio = vehiculoDTO.Precio,
                FechaEntrada = vehiculoDTO.FechaEntrada,
            };
            _context.Vehículo.Add(vehiculo);
            _context.SaveChanges();
        }

        public IEnumerable<VehiculoDTO> Get()
        {
            var vehiculos = _context.Vehículo.ToList();

            //Mapeo de Vehículo a VehiculoDTO
            List<VehiculoDTO> vehiculosDTO = new List<VehiculoDTO>();
            foreach (var i in vehiculos)
            {
                var vehiculo = new VehiculoDTO
                {
                    NumSerie = i.NumSerial,
                    Modelo = i.Modelo,
                    Marca = i.Marca,
                    Tipo = i.Tipo,
                    Precio = i.Precio,
                    FechaEntrada = i.FechaEntrada
                };
                vehiculosDTO.Add(vehiculo);
            }
            return vehiculosDTO;
        }
    }
}
