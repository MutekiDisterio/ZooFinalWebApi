using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.DAL.Entity;
using Zoo.DAL.Data;
using System.IO.Packaging;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Zoo.DAL.Data
{
    public class ZooManagementContext : DbContext
    {
        public ZooManagementContext() { }

        public ZooManagementContext(DbContextOptions<ZooManagementContext> options) : base(options) { }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;
        public virtual DbSet<Cage> Cages { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;
        public virtual DbSet<VolunteerDepartment> VolunteerDepartments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ZooDb;Username=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZooManagementContext).Assembly);
            SeedData.SeedDatao(modelBuilder);
        }

    }


}

