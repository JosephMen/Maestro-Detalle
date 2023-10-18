using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Crea una entidad nueva
        /// </summary>
        /// <param name="entity">la informacion del nuevo registro</param>
        /// <returns></returns>
        Task<TEntity> CreateAsync(TEntity entity);
        /// <summary>
        /// Actualiza la entidad
        /// </summary>
        /// <param name="entity">La informacion de la entidad</param>
        /// <returns>Un valor de verdad si se realizo correctamente</returns>
        Task<bool> UpdateAsync(TEntity entity);
        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="entity">La entidad con la informacion</param>
        /// <returns>Retorna un valor de verdad si fue eliminado correctamente</returns>
        Task<bool> DeleteAsync(TEntity entity);
        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns>Una lista con las entidades</returns>
        Task<IQueryable<TEntity>> GetAllAsync();
        /// <summary>
        /// Obtiene las entidades segun el predicado dado
        /// </summary>
        /// <param name="predicate">El predicado de busqueda</param>
        /// <returns>una lista con las entidades encontradas</returns>
        Task<IQueryable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate = null);
        /// <summary>
        /// Obtiene el primer elemento dado el predicado
        /// </summary>
        /// <param name="predicate">El predicado de busqueda</param>
        /// <returns>La entidad encontrada</returns>
        Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> predicate = null);
        
    }

}
