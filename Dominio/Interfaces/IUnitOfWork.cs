using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        public IEquipo Equipos {get;set;}
        public IJugador Jugadores {get;set;}
        public IPais Paises {get;set;}
        public IPosicion Posiciones {get;set;}
        Task<int> SaveAsync();
    }
}