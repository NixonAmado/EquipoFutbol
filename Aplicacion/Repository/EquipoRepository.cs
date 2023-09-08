using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class EquipoRepository : GenericRepository<Equipo>, IEquipo
    {
        private readonly TiendaContext _context;

        public EquipoRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Equipo> GetByIdAsync(int id)
        {
            return await _context.Equipos
                                .Include(p => p.Personas)
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Equipo>> GetAllAsync()
        {
            return await _context.Equipos
                                .Include(p => p.Personas)
                                .ToListAsync();
        }


    }