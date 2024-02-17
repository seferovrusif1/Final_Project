using FluentValidation.AspNetCore;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Profiles;
using JobSearch.Business.Repositories.Implements;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Implements;
using JobSearch.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();
            return services;
        }
        ///TODO: Add businnes layer for added mapper- dto 
        ///
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDTOValidator>());
            services.AddAutoMapper(typeof(AppUserMappingProfile).Assembly);
            return services;
        }
    }
}
