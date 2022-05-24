using App.Domain.Entities;
using App.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty,
                Login = "Admin"
            });
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = "3b62332e-4166-49fa-a20f-e7685b9565e4",
                UserName = "mykh_mm",
                NormalizedUserName = "Михайло Михайлович Михайлов",
                Speciality="Хірург",
                Email = "mykh.mm@email.com",
                NormalizedEmail = "myhk.mm@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "qwe123"),
                SecurityStamp = string.Empty,
                Login = "Михайло Михайлович Михайлов"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<Document>().HasData(new Document
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                DocumentType = "Cвідотцтво про народження",
                PatientId = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                AppUserId = "3b62332e-4166-49fa-a20f-e7685b9565e4"
            });
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                Name = "Валентин Якович Хміль",
                BirthDate = new DateTime(1993, 9, 13),
                PhoneNumber = "380-000-000-000"
            }) ;
            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                Name = "Віталій Андрійович Цаль",
                BirthDate = new DateTime(1995, 9, 13),
                PhoneNumber = "380-000-000-001"
            });
        }
    }
}
