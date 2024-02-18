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
    //public class JobSeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
    //{
    //    public void Configure(EntityTypeBuilder<JobSeeker> builder)
    //    {
    //        builder.Property(a => a.Skills)
    //            .HasMaxLength(1024);
    //        builder.Property(a => a.LanguageSkills)
    //            .HasMaxLength(512);
    //        builder.Property(a => a.Position)
    //            .IsRequired()
    //            .HasMaxLength(128);
    //        builder.Property(a => a.Name)
    //            .IsRequired()
    //            .HasMaxLength(32);
    //        builder.Property(a => a.Surname)
    //                        .IsRequired()
    //            .HasMaxLength(32);
    //        builder.Property(a => a.FatherName)
    //                        .IsRequired()
    //            .HasMaxLength(32);
    //        builder.Property(a => a.AdditionalInformation)
    //           .HasMaxLength(1024);
    //        builder.Property(a => a.BirthDate)
    //            .IsRequired()
    //            .HasColumnType("date");
    //        builder.Property(a => a.ExperienceDetail)
    //            .IsRequired().
    //            HasMaxLength(1024);
    //        builder.Property(a => a.EducationDetail)
    //                        .IsRequired().
    //                        HasMaxLength(1024);
    //        builder.Property(a => a.CVImgUrl)
    //            .HasMaxLength(64);
    //        builder.Property(a => a.ImageUrl)
    //            .HasMaxLength(64);
    //    }
    //}
}
