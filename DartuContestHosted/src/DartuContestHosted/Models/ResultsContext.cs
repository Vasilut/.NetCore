using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DartuContestHosted.Models
{
    public partial class ResultsContext : DbContext
    {
        public ResultsContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=tcp:dartuserver.database.windows.net,1433;Initial Catalog=Results;Persist Security Info=False;User ID=;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //Server=tcp:dartuserver.database.windows.net,1433;Initial Catalog=Results;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; azure
            //Data Source=DESKTOP-GBUDIMC;Initial Catalog=Results;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False local
            //Scaffold-DbContext "Data Source=DESKTOP-GBUDIMC;Initial Catalog=Results;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models ef command for db first
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezultate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clasa).HasColumnName("clasa");

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasColumnName("nume")
                    .HasMaxLength(100);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasColumnName("prenume")
                    .HasMaxLength(100);

                entity.Property(e => e.Scor).HasColumnName("scor");
            });
        }

        public virtual DbSet<Rezultate> Rezultate { get; set; }
    }
}