using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class TipoNominaRepository : GenericRepository<TipoNomina>, ITipoNomina
    {
        private readonly TiendaContext _context;

        public TipoNominaRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<TipoNomina> GetByIdAsync(int id)
        {
            return await _context.TipoNominas
                                .Include(p => p.Personas)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<TipoNomina>> GetAllAsync()
        {
            return await _context.TipoNominas
                                .Include(p => p.Personas)
                                .ToListAsync();
        }


    }