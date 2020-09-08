using System;
using System.Collections.Generic;
using System.Text;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GadeliniumGroupCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Pet Owner",
                    NormalizedName = "PETOWNER"
                },
                new IdentityRole
                {
                    Name = "Business Owner",
                    NormalizedName = "BUSINESSOWNER"
                });
        }
        
        public DbSet<Test> Tests{ get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Business> Buisnesses { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Boarding> Boardings { get; set; }
        public DbSet<PetBio> PetBios { get; set; }
        public DbSet<PetAccount> PetAccounts { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
