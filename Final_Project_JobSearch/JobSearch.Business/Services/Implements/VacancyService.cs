using AutoMapper;
using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class VacancyService : IVacancyService
    {
        IVacancyRepository _repo { get; }
        IMapper _mapper { get; }
        IPhoneRepository _phoneRepo { get; }
        IEmailRepository _emailRepo { get; }
        readonly string userId;
        IHttpContextAccessor _contextAccessor { get; }

        public VacancyService(IVacancyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo, IEmailRepository emailRepo)
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

        public async Task CreateAsync(VacancyCreateDTO dto)
        {
            //if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
            //    throw new Exception("Already exist");
            Vacancy data = new Vacancy
            {
                CategoryId = dto.CategoryId,
                Position = dto.Position,
                MaxSalaryId = dto.MaxSalaryId,
                AboutWork = dto.AboutWork,
                Requirements = dto.Requirements,
                MaxYas = dto.MaxYas,
                MinYas = dto.MinYas,
                GenderId = dto.GenderId,
                EducationId = dto.EducationId,
                ExperienceYearId = dto.ExperienceYearId,
                CityId = dto.CityId,
                TypeOfVacancyId = dto.TypeOfVacancyId,
                WorkTypeId = dto.WorkTypeId,
                AuthorizedPerson = dto.AuthorizedPerson,
                DeadLine = dto.DeadLine,
                Website = dto.Website,

            };
            data.UserId = userId;
            ///TODO:daha optimal ola bilerdi(ilk create edib exception tut ama unique lazmdi
            if (_emailRepo.GetIdFromEmail(dto.Email) == 0)
            {
                Email email = new Email { EmailAddress = dto.Email };
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
            data.LastActiveTime=DateTime.Now.AddDays(30);
            await _repo.CreateAsync(_mapper.Map<Vacancy>(data));
            await _repo.SaveAsync();
        }

        public IEnumerable<VacancyListItemDTO> GetAllActive()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "MaxSalary", "Gender", "Education", "ExperienceYear", "City", "TypeOfVacancy", "WorkType").Select(a => a.LastActiveTime > DateTime.Now && !a.IsDleted);
            return _mapper.Map<IEnumerable<VacancyListItemDTO>>(data);

        }
        public IEnumerable<VacancyListItemDTO> GetAll()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "MaxSalary", "Gender", "Education", "ExperienceYear", "City", "TypeOfVacancy", "WorkType");
            return _mapper.Map<IEnumerable<VacancyListItemDTO>>(data);

        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
        public async Task Confirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsConfirmed = true;
            await _repo.SaveAsync();

        }
        public async Task MakePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsPremium = true;
            await _repo.SaveAsync();

        }
        public async Task ReversePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsPremium = false;
            await _repo.SaveAsync();

        }
    }
}

