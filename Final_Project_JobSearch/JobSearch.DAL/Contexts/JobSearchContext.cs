using JobSearch.Core.Entities;
using JobSearch.Core.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.DAL.Contexts
{
    public class JobSearchContext : IdentityDbContext<AppUser>
    {
        public JobSearchContext(DbContextOptions options) : base(options){}
        public DbSet<Company> Companys { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedTime = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
