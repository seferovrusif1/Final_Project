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
        public Task CreateAsync(Company dto);
    }
}
