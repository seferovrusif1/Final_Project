using AutoMapper;
using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Profiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<Company, CompanyListItemDTO>();

        }
    }
}
