using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    internal class GabinetContext : DbContext
    {
        public GabinetContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-4E1085R;Initial Catalog=gabinet;Integrated Security=True");
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Grafik> Grafik { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Receptionist> Receptionist { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Specialization> Specialization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grafik>().HasOne(d => d.Doctor);
            modelBuilder.Entity<Grafik>().HasOne(d => d.Patient);
        }
    }
}