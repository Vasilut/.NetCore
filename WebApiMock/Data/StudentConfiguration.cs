using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
            entity.ToTable("Student");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).HasColumnName("Id");
            entity.Property(r => r.Name).HasColumnName("Name");
            entity.Property(r => r.Age).HasColumnName("Age");
        }
    }
}
