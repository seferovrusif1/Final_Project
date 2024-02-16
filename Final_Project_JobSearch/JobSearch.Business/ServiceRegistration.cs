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
            services.AddScoped<ICompanyService, CompanyService>();
            return services;
        }
        ///TODO: Add businnes layer for added mapper- dto 
    }
}
