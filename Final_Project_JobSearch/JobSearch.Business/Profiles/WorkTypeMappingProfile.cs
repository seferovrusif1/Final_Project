using AutoMapper;
using JobSearch.Business.DTOs.WorkTypeDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class WorkTypeMappingProfile: Profile
    {
        public WorkTypeMappingProfile()
    {
        CreateMap<WorkTypeCreateDTO, SocialMedia>();
        CreateMap<SocialMedia, WorkTypeListItemDTO>();
    }
}
}
