using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TiendaContext _context;
        private EquipoRepository _equipos;
        private JugadorRepository _jugadores;
        private PaisRepository _paises;
        private PersonaRepository _personas;
        private PosicionRepository _posicion;
        private TipoNominaRepository _tipoNominas;


        public UnitOfWork(TiendaContext context)
        {
            _context = context;
        }
        public IEquipo Equipos
        {
            get {
                    if(_equipos == null)
                    {
                        _equipos =  new EquipoRepository(_context);
                    }
                    return _equipos;
                }
        }
        public IJugador Jugadores
        {
            get {
                    if(_jugadores == null)
                    {
                        _jugadores =  new JugadorRepository(_context);
                    }
                    return _jugadores;
                }
        }
        public IPais Paises
        {
            get {
                    if(_paises == null)
                    {
                        _paises =  new PaisRepository(_context);
                    }
                    return _paises;
                }
        }
        public IPersona Personas
        {
            get {
                    if(_personas == null)
                    {
                        _personas =  new PersonaRepository(_context);
                    }
                    return _personas;
                }
        }
        public IPosicion Posiciones
        {
            get {
                    if(_posicion == null)
                    {
                        _posicion =  new PosicionRepository(_context);
                    }
                    return _posicion;
                }
        }
        public ITipoNomina TipoNominas
        {
            get {
                    if(_tipoNominas == null)
                    {
                        _tipoNominas =  new TipoNominaRepository(_context);
                    }
                    return _tipoNominas;
                }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
}
