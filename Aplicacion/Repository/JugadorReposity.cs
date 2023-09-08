using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class JugadorRepository : GenericRepository<Jugador>, IJugador
    {
        private readonly TiendaContext _context;

        public JugadorRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Jugador> GetByIdAsync(int id)
        {
            return await _context.Jugadores
                                .Include(p => p.Posiciones)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Jugador>> GetAllAsync()
        {
            return await _context.Jugadores
                                .Include(p => p.Posiciones)
                                .ToListAsync();
        }


    }