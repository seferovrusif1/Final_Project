using AutoMapper;
using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using JobSearch.Business.Profiles;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Profiles
{
    public class TypeOfVacancyMappingProfile : Profile
    {
        public TypeOfVacancyMappingProfile()
        {
            CreateMap<TypeOfVacancyCreateDTO, TypeOfVacancy>();
            CreateMap<TypeOfVacancy, TypeOfVacancyListItemDTO>();
        }
    }
}
