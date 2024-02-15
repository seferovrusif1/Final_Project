using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICompanyService
    {
        ///TODO:dto ile deyisdir
        public IEnumerable<Company> GetAll();
        public Task<Company> GetByIdAsync(int id);
        public Task CreateAsync(Company dto);
        public Task RemoveAsync(int id);
        public Task UpdateAsync(int id, Company dto);
    }
}
