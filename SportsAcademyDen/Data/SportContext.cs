using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Data
{
    public class SportContext : DbContext
    {
        public SportContext (DbContextOptions<SportContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().ToTable("Coach");
            modelBuilder.Entity<Sport>().ToTable("Sport");
            modelBuilder.Entity<Fixture>().ToTable("Fixture");
            modelBuilder.Entity<Player>().ToTable("Player");
        }
    }
}
