using AutoMapper;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
