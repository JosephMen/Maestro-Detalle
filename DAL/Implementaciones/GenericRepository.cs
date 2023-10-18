using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DAL.Models;

namespace DAL.Implementaciones
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AtomContext _context;

        public GenericRepository(AtomContext context)
        {
            _context = context;
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }catch (Exception) {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
               _context.Set<TEntity>().Remove(entity); 
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception)
            { 
                throw;
            }
        }

        public async Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    return _context.Set<TEntity>();
                }
                return _context.Set<TEntity>().Where(predicate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            try
            {
                IQueryable <TEntity> entity = _context.Set<TEntity>();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                TEntity? entity = await _context.Set<TEntity>().FirstOrDefaultAsync();
                return entity;
            }catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync(); 
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
