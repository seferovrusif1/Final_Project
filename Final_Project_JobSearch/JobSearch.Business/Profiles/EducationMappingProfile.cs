using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class EducationMappingProfile : Profile
    {
        public EducationMappingProfile()
        {
            CreateMap<EducationCreateDTO, Education>();
            CreateMap<Education, EducationListItemDTO>();
        }
    }
}
