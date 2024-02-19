using AutoMapper;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class CompanyService:ICompanyService
    {
        ICompanyRepository _repo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;

        public CompanyService(ICompanyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
        }

        ///TODO:DTO lar ,mapper, exceptionlari duzelt
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

     
    }
}
