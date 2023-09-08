using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistencia;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork
    {
        private readonly TiendaContext _context;

        public UnitOfWork(TiendaContext context)
        {
            _context = context;
        }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
        }
        
}
