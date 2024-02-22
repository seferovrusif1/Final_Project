using AutoMapper;
using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _repo { get; }
        IPhoneRepository _phoneRepo { get; }
        IEmailRepository _emailRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;

        public CompanyService(ICompanyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo, IEmailRepository emailRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
            _phoneRepo = phoneRepo;
            _emailRepo = emailRepo;
        }

     
        public async Task CreateAsync(CompanyCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new AlreadyExistException<Company>();
            Company data = new Company
            {
                About = dto.About,
                Name = dto.Name,
                AuthorizedPerson = dto.AuthorizedPerson,
                Website = dto.Website,
                IsConfirmed = false
            };
            data.UserId= userId;
            ///TODO:daha optimal ola bilerdi(ilk create edib exception tut ama unique lazmdi
            if (_emailRepo.GetIdFromEmail(dto.Email) == 0)
            {
                Email email = new Email { EmailAddress = dto.Email};
                await _emailRepo.CreateAsync(email);
                await _emailRepo.SaveAsync();
            }
            data.EmailId = _emailRepo.GetIdFromEmail(dto.Email);

            if (_phoneRepo.GetIdFromNumber(dto.Phone) == 0)
            {
                Phone phone = new Phone { Number = dto.Phone };
                await _phoneRepo.CreateAsync(phone);
                await _phoneRepo.SaveAsync();
            }
            data.PhoneId = _phoneRepo.GetIdFromNumber(dto.Phone);
            await _repo.CreateAsync(data);

            await _repo.SaveAsync();
        }
        IEnumerable<CompanyListItemDTO> ICompanyService.GetAllActive()
        {
            var data = _repo.GetAll(true, "Phone", "Email").Select(a => !a.IsDleted);
            return _mapper.Map<IEnumerable<CompanyListItemDTO>>(data);
        }
        public IEnumerable<CompanyListItemDTO> GetAll()
        {
            var data=_repo.GetAll(true,"Phone","Email");
            return  _mapper.Map<IEnumerable<CompanyListItemDTO>>(data);
        }
        
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
        public async Task Confirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            data.IsConfirmed = true;
            await _repo.SaveAsync();

        }

       
    }
}
