using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektZaliczeniowy
{
    public class GabinetContext : DbContext
    {
        public GabinetContext() : base()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"Data Source=DESKTOP-4E1085R;Initial Catalog=gabinet;Integrated Security=True");
            options.UseSqlServer("Initial Catalog=gabinet;Integrated Security=True");
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Grafik> Grafik { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Specialization> Specialization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grafik>().HasOne(p => p.Doctor).WithMany(s => s.Grafik).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grafik>().HasOne(p => p.Patient).WithMany(s => s.Grafik).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Grafik>().HasOne(p => p.Room).WithMany(s => s.Grafik).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData
                (new Role { Name = "Administrator", Id = 1 },
                new Role { Name = "Reader", Id = 2 },
                new Role { Name = "Writer", Id = 3 }
                );

            modelBuilder.Entity<Specialization>().HasData
                (new Specialization { Id = 1, Value = "Lekarz rodzinny" },
                 new Specialization { Id = 2, Value = "Endokrynolog" },
                 new Specialization { Id = 3, Value = "Laryngolog" },
                 new Specialization { Id = 4, Value = "Stomatolog" }
                );

            modelBuilder.Entity<Room>().HasData
             (new Room { Id = 1, Number = 1 },
              new Room { Id = 2, Number = 2 },
              new Room { Id = 3, Number = 3 },
              new Room { Id = 4, Number = 4 }
             );

            modelBuilder.Entity<Patient>().HasData
                (new Patient { Id = 1, Name = "Adam Nowak ", Adress = " Magnoliowa 5", Pesel = 85011259884, RoleId = 3, Password = "Admin123!" },
                new Patient { Id = 2, Name = "Zofia Stefaniuk", Adress = " Ostoja 5", Pesel = 78020607221, RoleId = 2, Password = "Admin123!" },
                new Patient { Id = 3, Name = "Austen Nowaki", Adress = " Żeromskiego 4", Pesel = 95011259884, RoleId = 2, Password = "Admin123!" },
                new Patient { Id = 4, Name = "Grzegorz Fus", Adress = " Obozowa 15", Pesel = 65011259884, RoleId = 2, Password = "Admin123!" }
                 );
            modelBuilder.Entity<Nurse>().HasData
                (new Nurse { Id = 1, NameSurname = "AZofia Stanecka", Adress = " Różana 5", PermissionNumber = " 509853", RoleId = 1, Password = "Admin123!" },
                new Nurse { Id = 2, NameSurname = "Hanna Oklejka", Adress = " Topografów 5", PermissionNumber = " 510053", RoleId = 3, Password = "Admin123!" },
                new Nurse { Id = 3, NameSurname = "Anna Austen", Adress = " os. Kolorowe 8", PermissionNumber = " 169053", RoleId = 3, Password = "Admin123!" },
                new Nurse { Id = 4, NameSurname = "Glżbieta Lem", Adress = " Obozowa 14", PermissionNumber = " 567053", RoleId = 3, Password = "Admin123!" }
                 );

            modelBuilder.Entity<Doctor>().HasData
               (new Doctor { Id = 1, NameSurname = "Adam Kowalski", Adress = " Kolorowa 5", PermissionNumber = " 569853", RoleId = 3, SpecializationId = 1, Password = "Admin123!" },
               new Doctor { Id = 2, NameSurname = "Zofia Kowalski", Adress = " Zielona 5", PermissionNumber = " 560053", RoleId = 3, SpecializationId = 2, Password = "Admin123!" },
               new Doctor { Id = 3, NameSurname = "Todor Nowaki", Adress = " Adama Mickiewicza 8", PermissionNumber = " 160053", RoleId = 3, SpecializationId = 3, Password = "Admin123!" },
               new Doctor { Id = 4, NameSurname = "Grzegorz Lem", Adress = " Obozowa 8", PermissionNumber = " 560053", RoleId = 3, SpecializationId = 4, Password = "Admin123!" }
                );

            modelBuilder.Entity<Grafik>().HasData
            (new Grafik { Id = 1, PatientId = 1, DoctorId = 1, RoomId = 1, Data = new DateTime(2022, 05, 10) },
             new Grafik { Id = 2, PatientId = 2, DoctorId = 2, RoomId = 2, Data = new DateTime(2022, 05, 10) },
             new Grafik { Id = 3, PatientId = 3, DoctorId = 3, RoomId = 3, Data = new DateTime(2022, 10, 10) },
             new Grafik { Id = 4, PatientId = 4, DoctorId = 3, RoomId = 4, Data = new DateTime(2022, 10, 10) }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}