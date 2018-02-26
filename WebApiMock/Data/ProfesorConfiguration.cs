using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> entity)
        {
            entity.ToTable("Profesor");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).HasColumnName("Id");
            entity.Property(r => r.Name).HasColumnName("Name");
            entity.Property(r => r.Disciplina).HasColumnName("Disciplina");
        }
    }
}
