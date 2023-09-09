using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;    
    
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        private readonly TiendaContext _context;

        public PersonaRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas
                                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas
                                .ToListAsync();
        }


    }