﻿using JobSearch.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobSearch.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
        
    {
        DbSet<T> Table { get; }
        Task CreateAsync(T data);
        IQueryable<T> GetAll(bool noTracking = true, params string[] include);
        Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] include);
        void Remove(T data);
        Task SaveAsync();
    }
}
