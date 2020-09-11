﻿// <auto-generated />
using System;
using GadeliniumGroupCapstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GadeliniumGroupCapstone.Migrations
{
    [DbContext(typeof(PetAppDbContext))]
    partial class PetAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Boarding", b =>
                {
                    b.Property<int>("BoardingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("BoardingId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Boardings");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoBinId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusinessId");

                    b.HasIndex("PhotoBinId");

                    b.HasIndex("UserId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Groomer", b =>
                {
                    b.Property<int>("GroomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("GroomerId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Groomers");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("GuestId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Immunization", b =>
                {
                    b.Property<int>("ImmunizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImmunizationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("int");

                    b.HasKey("ImmunizationId");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("immunizations");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.MedicalRecord", b =>
                {
                    b.Property<int>("MedicalRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.HasKey("MedicalRecordId");

                    b.HasIndex("PetId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<string>("MedicationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicationId");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("medications");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Other", b =>
                {
                    b.Property<int>("OtherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("OtherId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Others");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.PetAccount", b =>
                {
                    b.Property<int>("PetAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimalType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("PetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PetAccountId");

                    b.HasIndex("UserId");

                    b.ToTable("PetAccounts");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.PetBio", b =>
                {
                    b.Property<int>("PetBioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dislikes")
                        .HasColumnType("int");

                    b.Property<string>("Hobbies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("PetInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PetBioId");

                    b.HasIndex("PetId");

                    b.ToTable("PetBios");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.PhotoBin", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PhotoId");

                    b.ToTable("PhotoBins");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceDisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("ServiceFurtherDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceThumbnailPhotoId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("BusinessId");

                    b.HasIndex("ServiceThumbnailPhotoId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Sitter", b =>
                {
                    b.Property<int>("SitterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("SitterId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Sitters");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("PetAppUsers");

                    b.HasData(
                        new
                        {
                            Id = "08985f88-f992-417e-ba80-c0324683ea91",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1aa9c963-47d8-466c-b25c-c5dc783d6cfc",
                            Email = "Choua@choua.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "CHOUA@CHOUA.COM",
                            NormalizedUserName = "CHOUA@CHOUA.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEL1tat7CzuP3E74HMHZg46VOIRV8zU2OrGlrZiiZ1lOE95v65PMnd45XoNFQRRepjQ==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "HWS6RX53NTMKWLVBRAQNCIKIFAUQ3FPK",
                            TwoFactorEnabled = false,
                            UserName = "Choua@choua.com"
                        },
                        new
                        {
                            Id = "5b339db7-fd08-4ffe-9467-4695dee7bd65",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1fdd1d6-884c-4d28-bd50-a6f32e6bfbe1",
                            Email = "Tim@tim.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "TIM@TIM.COM",
                            NormalizedUserName = "TIM@TIM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEG6euUT06GKNaSJe2Ksy0sRvdp+HJVJFBGPtqclwdvbu7S8IWdVhamthAkZPrLbTfQ==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "IKYVWNRLBUNDPYA2FTNX5TCFYZWCS7OO",
                            TwoFactorEnabled = false,
                            UserName = "Tim@tim.com"
                        },
                        new
                        {
                            Id = "d453a413-17b1-4f27-89d8-8f26af48f90b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9bcc49dc-5974-4ae5-8350-cb95c257d550",
                            Email = "Sam@sam.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "SAM@SAM.COM",
                            NormalizedUserName = "SAM@SAM.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGsIaD6NQJAT3n+lzCO4sEaNFKfc4NVzi8A6MoNnlCJsoehkvqPkbRTDbOjLr2tKbQ==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4ZIGJCZL4JJEWK7PDYDN467AR3AVFJU7",
                            TwoFactorEnabled = false,
                            UserName = "Sam@sam.com"
                        },
                        new
                        {
                            Id = "d8195859-5968-48a5-b400-2afa2e29f775",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8e3ea5b9-3cc2-4d52-8f2b-1b993dd7732e",
                            Email = "Milan@Milan.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "MILAN@MILAN.COM",
                            NormalizedUserName = "MILAN@MILAN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPvPMaCo9UmPJVbeV+Btd3Y83X5Eyekn/hwXRbcfZEKrwB2welahQAJkL6ZjGZkeQw==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4PHNLV4WVA7LCIA3S2QNDCYQGRCY6WJS",
                            TwoFactorEnabled = false,
                            UserName = "Milan@Milan.com"
                        });
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Vet", b =>
                {
                    b.Property<int>("VetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.HasKey("VetId");

                    b.HasIndex("BusinessId");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("PetAppRoles");

                    b.HasData(
                        new
                        {
                            Id = "934c9a36-f8d5-48b6-a85f-eda612a49e53",
                            ConcurrencyStamp = "427f4e7c-c41e-4d4e-a184-8b1ab35f31ba",
                            Name = "Pet Owner",
                            NormalizedName = "PETOWNER"
                        },
                        new
                        {
                            Id = "2defdc66-1909-4b47-a51e-2a89d63d4a94",
                            ConcurrencyStamp = "aab86285-0b81-4986-af0b-8f6c5dfc769a",
                            Name = "Business Owner",
                            NormalizedName = "BUSINESSOWNER"
                        },
                        new
                        {
                            Id = "c8a170dd-32ba-4c22-bd53-3fca5aa31dea",
                            ConcurrencyStamp = "83d264b4-3a49-4961-89dc-ecfecb7141b0",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("PetAppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PetAppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("PetAppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("PetAppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("PetAppUserTokens");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Boarding", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Business", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.PhotoBin", "BusinessLogo")
                        .WithMany()
                        .HasForeignKey("PhotoBinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GadeliniumGroupCapstone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Groomer", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Immunization", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.MedicalRecord", "medicalRecord")
                        .WithMany()
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.MedicalRecord", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.PetAccount", "PetAccount")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Medication", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.MedicalRecord", "medicalRecord")
                        .WithMany()
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Other", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.PetAccount", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.PetBio", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.PetAccount", "PetAccount")
                        .WithMany()
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Service", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany("Services")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GadeliniumGroupCapstone.Models.PhotoBin", "ServiceThumbnail")
                        .WithMany()
                        .HasForeignKey("ServiceThumbnailPhotoId");
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Sitter", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Trainer", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GadeliniumGroupCapstone.Models.Vet", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.User", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.User", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GadeliniumGroupCapstone.Models.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GadeliniumGroupCapstone.Models.User", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
