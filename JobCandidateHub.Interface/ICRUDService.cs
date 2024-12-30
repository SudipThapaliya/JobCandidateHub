using JobCandidateHub.Entity;
using System.Linq.Expressions;

namespace JobCandidateHub.Interface
{
    public interface ICRUDService<TEntity> where TEntity : BaseEntity
    {
        Task<bool> Exist(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task Save();
    }
}
