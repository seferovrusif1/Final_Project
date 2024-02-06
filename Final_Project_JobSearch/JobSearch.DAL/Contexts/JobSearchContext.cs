using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DAL.Contexts
{
    public class JobSearchContext : IdentityDbContext<AppUser>
    {
        public JobSearchContext(DbContextOptions options) : base(options)
        {
        }
    }
}
