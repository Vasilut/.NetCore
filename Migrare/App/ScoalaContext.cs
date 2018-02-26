using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App
{
    public partial class ScoalaContext : DbContext
    {
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        /*
         * Scaffold-DbContext "Host=localhost;Database=mydatabase;Username=myuser;Password=mypassword" Npgsql.EntityFrameworkCore.PostgreSQL
         */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=192.168.111.140;Port=5432;Database=Scoala;User Id=postgres;Password=password01!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
