
using System.Linq.Expressions;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Dominio.Interfaces;

namespace Aplicacion.Repository;

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
    private readonly TiendaContext _context;

    public GenericRepository(TiendaContext context)
    {
        _context = context;
    }

    public Task<T> GetByAsync(int id)
    {
        throw new NotImplementedException(); 
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return  await _context.Set<T>().FindAsync(id);
    }

    public virtual  IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
         return _context.Set<T>().Where(expression);
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
    public virtual void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }
    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<T> registros)>GetAllAsync(int PageIndex, int PageSize, string _search)
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>()
                        .Skip((PageIndex -1 ) * PageSize)
                        .Take(PageSize)
                        .ToListAsync();
        return(totalRegistros,registros);
    }



}   
