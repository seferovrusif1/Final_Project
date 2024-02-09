using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.DAL.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            ///TODO:relation-lari qur
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(b => b.Surname)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
