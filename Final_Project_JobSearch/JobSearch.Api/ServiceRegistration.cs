using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Api
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                ///TODO: duzenle
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<JobSearchContext>();
            return services;
        }
    }
}
