using AutoMapper;
using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class JobSeekerService : IJobSeekerService
    {
        IJobSeekerRepository _repo { get; }
        IMapper _mapper { get; }
        IPhoneRepository _phoneRepo { get; }
        IEmailRepository _emailRepo { get; }
        readonly string userId;
        IHttpContextAccessor _contextAccessor { get; }

        public JobSeekerService(IJobSeekerRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo, IEmailRepository emailRepo)
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

        public async Task CreateAsync(JobSeekerCreateDTO dto)
        {
            //if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
            //    throw new Exception("Already exist");
            ///TODO:getbyid ile parent id olub olmadigini tap
            JobSeeker data = new JobSeeker
            {
                Name=dto.Name,
                Surname=dto.Surname,
                FatherName=dto.FatherName,
                ImageUrl=dto.ImageUrl,
                CVImgUrl=dto.CVImgUrl,
                CategoryId = dto.CategoryId,
                GenderId = dto.GenderId,
                EducationId = dto.EducationId,
                EducationDetail=dto.EducationDetail,
                ExperienceYearId = dto.ExperienceYearId,
                ExperienceDetail=dto.ExperienceDetail,
                Position = dto.Position,
                CityId = dto.CityId,
                Skills = dto.Skills,
                LanguageSkills=dto.LanguageSkills,
                AdditionalInformation  =dto.AdditionalInformation,
                BirthDate= dto.BirthDate,
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
            await _repo.CreateAsync(_mapper.Map<JobSeeker>(data));
            await _repo.SaveAsync();
        }

        public IEnumerable<JobSeekerListItemDTO> GetAll()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "Gender", "Education", "ExperienceYear", "City");
            return _mapper.Map<IEnumerable<JobSeekerListItemDTO>>(data);

        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
    }
}


