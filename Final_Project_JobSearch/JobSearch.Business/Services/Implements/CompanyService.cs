using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class CompanyService:ICompanyService
    {
        ICompanyRepository _repo { get; }
        //IMapper _mapper { get; }


        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        ///TODO:DTO lari exceptionlari duzelt
        public async Task CreateAsync(Company dto)
        {
            await _repo.CreateAsync(dto);
            await _repo.SaveAsync();
        }

        public IEnumerable<Company> GetAll()
            => _repo.GetAll();

     
        public async Task RemoveAsync(int id)
        {
            var data = await _checkId(id);
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

      
        async Task<Company> _checkId(int id, bool isTrack = false)
        {
            if (id <= 0) throw new ArgumentException();
            var data = await _repo.GetByIdAsync(id, isTrack);
            if (data == null) throw new Exception();
            return data;
        }

        Task<Company> ICompanyService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Company dto)
        {
            throw new NotImplementedException();
        }
    }
}
