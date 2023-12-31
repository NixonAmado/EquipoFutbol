using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        private readonly TiendaContext _context;

        public PaisRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                                .ToListAsync();
        }

        public override async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises
                                .Include(p => p.Equipos)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

       


    }