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
    public class PetAppDbContext : IdentityDbContext<User>
    {
        public IConfiguration Configuration { get; }

        public PetAppDbContext(DbContextOptions<PetAppDbContext> options, IConfiguration configuration)
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
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                });


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<User>(b =>
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

                b.ToTable("PetAppUsers");

                // Seed the User table
                b.HasData(
                    new User
                    {
                        Id = "08985f88-f992-417e-ba80-c0324683ea91",
                        UserName = "Choua@choua.com",
                        NormalizedUserName = "CHOUA@CHOUA.COM",
                        Email = "Choua@choua.com",
                        NormalizedEmail = "CHOUA@CHOUA.COM",
                        EmailConfirmed = false,
                        PasswordHash = "AQAAAAEAACcQAAAAEL1tat7CzuP3E74HMHZg46VOIRV8zU2OrGlrZiiZ1lOE95v65PMnd45XoNFQRRepjQ==",
                        SecurityStamp = "HWS6RX53NTMKWLVBRAQNCIKIFAUQ3FPK",
                        ConcurrencyStamp = "1aa9c963-47d8-466c-b25c-c5dc783d6cfc",
                        PhoneNumber = "555-555-5555",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new User
                    {
                    Id = "5b339db7-fd08-4ffe-9467-4695dee7bd65",
                    UserName = "Tim@tim.com",
                    NormalizedUserName = "TIM@TIM.COM",
                    Email = "Tim@tim.com",
                    NormalizedEmail = "TIM@TIM.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEG6euUT06GKNaSJe2Ksy0sRvdp+HJVJFBGPtqclwdvbu7S8IWdVhamthAkZPrLbTfQ==",
                    SecurityStamp = "IKYVWNRLBUNDPYA2FTNX5TCFYZWCS7OO",
                    ConcurrencyStamp = "d1fdd1d6-884c-4d28-bd50-a6f32e6bfbe1",
                    PhoneNumber = "555-555-5555",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                    },
                    new User
                    {
                    Id = "d453a413-17b1-4f27-89d8-8f26af48f90b",
                    UserName = "Sam@sam.com",
                    NormalizedUserName = "SAM@SAM.COM",
                    Email = "Sam@sam.com",
                    NormalizedEmail = "SAM@SAM.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEGsIaD6NQJAT3n+lzCO4sEaNFKfc4NVzi8A6MoNnlCJsoehkvqPkbRTDbOjLr2tKbQ==",
                    SecurityStamp = "4ZIGJCZL4JJEWK7PDYDN467AR3AVFJU7",
                    ConcurrencyStamp = "9bcc49dc-5974-4ae5-8350-cb95c257d550",
                    PhoneNumber = "555-555-5555",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                    },
                    new User
                    {
                     Id = "d8195859-5968-48a5-b400-2afa2e29f775",
                     UserName = "Milan@Milan.com",
                     NormalizedUserName = "MILAN@MILAN.COM",
                     Email = "Milan@Milan.com",
                     NormalizedEmail = "MILAN@MILAN.COM",
                     EmailConfirmed = false,
                     PasswordHash = "AQAAAAEAACcQAAAAEPvPMaCo9UmPJVbeV+Btd3Y83X5Eyekn/hwXRbcfZEKrwB2welahQAJkL6ZjGZkeQw==",
                     SecurityStamp = "4PHNLV4WVA7LCIA3S2QNDCYQGRCY6WJS",
                     ConcurrencyStamp = "8e3ea5b9-3cc2-4d52-8f2b-1b993dd7732e",
                     PhoneNumber = "555-555-5555",
                     PhoneNumberConfirmed = false,
                     TwoFactorEnabled = false,
                     LockoutEnabled = true,
                     AccessFailedCount = 0
                    }
                    );


            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("PetAppUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("PetAppUserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("PetAppUserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("PetAppRoles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("PetAppRoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("PetAppUserRoles");
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
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Other> Others { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Boarding> Boardings { get; set; }
        public DbSet<PetBio> PetBios { get; set; }
        public DbSet<PetAccount> PetAccounts { get; set; }
        public DbSet<Service> Services { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<PhotoBin> PhotoBins { get; set; }
        public DbSet<BusinessHour> BusinessHours{ get; set; }

    }
}
