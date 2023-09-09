using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        public IEquipo Equipos {get;}
        public IJugador Jugadores {get;}
        public IPais Paises {get;}
        public IPersona Personas {get;}
        public IPosicion Posiciones {get;}
        public ITipoNomina TipoNominas {get;}
        Task<int> SaveAsync();
    }
}