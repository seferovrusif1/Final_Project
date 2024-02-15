using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities.Common;
using JobSearch.DAL.Contexts;

namespace JobSearch.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public JobSearchContext _context {get;}

        public GenericRepository(JobSearchContext context)
        {
            _context = context;
        }

        public Task CreateAsync(T data)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll(bool noTracking = true, params string[] include)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include)
        {
            throw new NotImplementedException();
        }

        public void Remove(T data)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
