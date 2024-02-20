using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities.Common;
using JobSearch.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace JobSearch.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public JobSearchContext _context {get;}

        public GenericRepository(JobSearchContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T data)
        {
            await Table.AddAsync(data);
        }
        ///TODO: tekrar nezer yetir
        public IQueryable<T> GetAll(bool noTracking = true, params string[] include)
        {
            IQueryable<T> query=Table.AsQueryable();
            if (include != null && include.Length > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return noTracking ? query.AsNoTracking() : query;
        }


        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }



        public Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include)
        {
            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
