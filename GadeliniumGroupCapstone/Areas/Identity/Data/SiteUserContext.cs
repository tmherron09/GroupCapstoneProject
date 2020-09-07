using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GadeliniumGroupCapstone.Data
{
    public class SiteUserContext : IdentityDbContext<SiteUser>
    {
        //public SiteUserContext(DbContextOptions<SiteUserContext> options)
        //    : base(options)
        //{
        //}
        public IConfiguration Configuration { get; }

        public SiteUserContext(DbContextOptions<SiteUserContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
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



            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<SiteUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                 .WithOne()
                 .HasForeignKey(uc => uc.UserId)
                 .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne()
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne()
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                b.ToTable("SiteUsers");




            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("SiteUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("SiteUserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("SiteUserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("SiteRoles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("SiteRoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("SiteUserRoles");
            });

        }

        // Override but call base method. This will allow calling a parameterless constructor in the Startup Services.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));


        }

        public DbSet<Test> Tests { get; set; }
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
        public DbSet<SiteUser> SiteUsers { get; set; }

    }
}
