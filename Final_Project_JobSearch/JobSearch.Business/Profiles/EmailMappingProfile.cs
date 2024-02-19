using AutoMapper;
using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Profiles
{
    public class EmailMappingProfile : Profile
    {
        public EmailMappingProfile()
        {
            CreateMap<EmailCreateDTO, Email>();
            CreateMap<Email, EmailListItemDTO>();
        }
    }
}
