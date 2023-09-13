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

        public override async  Task<(int totalRegistros,IEnumerable<Equipo> registros)> GetAllAsync(int pageIndex,int pageSize, string _search)
        {
            var query = _context.Equipos as IQueryable<Equipo>;
            if(!string.IsNullOrEmpty(_search))
            {
                query = query.Where(p => p.Nombre.ToLower().Contains(_search));
            }
            var totalRegistros = await query.CountAsync();
            var registros = await query
                                  .Include(u => u.Personas)
                                  .Skip((pageIndex - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();
            return (totalRegistros, registros);
        }

    }