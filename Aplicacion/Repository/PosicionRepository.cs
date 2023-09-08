using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class PosicionRepository : GenericRepository<Posicion>, IPosicion
    {
        private readonly TiendaContext _context;

        public PosicionRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Posicion> GetByIdAsync(int id)
        {
            return await _context.Posiciones
                                .Include(p => p.Jugadores)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Posicion>> GetAllAsync()
        {
            return await _context.Posiciones
                                .Include(p => p.Jugadores)
                                .ToListAsync();
        }


    }