using JobCandidateHub.Core;
using JobCandidateHub.Entity;
using JobCandidateHub.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq.Expressions;

namespace JobCandidateHub.Service
{
    public class CRUDService<T> : ICRUDService<T> where T : BaseEntity
    {
        public readonly JobCandidateHubDbContext _context;

        public CRUDService(JobCandidateHubDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Exist(Expression<Func<T, bool>> expression)
        {
            try
            {
                bool entity = await _context.Set<T>().AnyAsync(expression);
                return entity;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _context.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                var sql = await _context.Set<T>().AddAsync(entity);
                return sql.Entity;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public T Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
    }
}
