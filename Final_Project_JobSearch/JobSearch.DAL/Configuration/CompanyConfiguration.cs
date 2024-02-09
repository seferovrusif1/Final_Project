using JobSearch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.DAL.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(a => a.About)
               .HasMaxLength(2048);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.AuthorizedPerson)
                .IsRequired()
               .HasMaxLength(64);
            builder.Property(a => a.Website)
                .IsRequired()
                .HasMaxLength(256);
        }

    }
}
