using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DartuContestHosted.Models
{
    public partial class ResultsContext : DbContext
    {
        public ResultsContext(DbContextOptions options) : base(options)
        {
            /*
             * Scaffold-DbContext "Data Source=DESKTOP-GBUDIMC;Initial Catalog=Results;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
             */
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GBUDIMC;Initial Catalog=Results;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezultate>(entity =>
            {
                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Scoala)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }

        public virtual DbSet<Rezultate> Rezultate { get; set; }
    }
}