using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class INITafternuke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    BusinessHourId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOpenMonday = table.Column<bool>(nullable: false),
                    MondayOpening = table.Column<int>(nullable: false),
                    MondayClosing = table.Column<int>(nullable: false),
                    IsOpenTuesday = table.Column<bool>(nullable: false),
                    TuesdayOpening = table.Column<int>(nullable: false),
                    TuesdayClosing = table.Column<int>(nullable: false),
                    IsOpenWednesday = table.Column<bool>(nullable: false),
                    WednesdayOpening = table.Column<int>(nullable: false),
                    WednesdayClosing = table.Column<int>(nullable: false),
                    IsOpenThursday = table.Column<bool>(nullable: false),
                    ThursdayOpening = table.Column<int>(nullable: false),
                    ThursdayClosing = table.Column<int>(nullable: false),
                    IsOpenFriday = table.Column<bool>(nullable: false),
                    FridayOpening = table.Column<int>(nullable: false),
                    FridayClosing = table.Column<int>(nullable: false),
                    IsOpenSaturday = table.Column<bool>(nullable: false),
                    SaturdayOpening = table.Column<int>(nullable: false),
                    SaturdayClosing = table.Column<int>(nullable: false),
                    IsOpenSunday = table.Column<bool>(nullable: false),
                    SundayOpening = table.Column<int>(nullable: false),
                    SundayClosing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.BusinessHourId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "PetAppRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PetAppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    NormalizedFirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NormalizedLastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoBins",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoBins", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "PetAppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetAppRoleClaims_PetAppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PetAppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetAccounts",
                columns: table => new
                {
                    PetAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breed = table.Column<string>(nullable: true),
                    PetName = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    AnimalType = table.Column<string>(nullable: true),
                    PetPhone = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAccounts", x => x.PetAccountId);
                    table.ForeignKey(
                        name: "FK_PetAccounts_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PetAppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetAppUserClaims_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetAppUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_PetAppUserLogins_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetAppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PetAppUserRoles_PetAppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PetAppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetAppUserRoles_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetAppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAppUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_PetAppUserTokens_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    BusinessHourId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    PhotoBinId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessHours_BusinessHourId",
                        column: x => x.BusinessHourId,
                        principalTable: "BusinessHours",
                        principalColumn: "BusinessHourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Businesses_PhotoBins_PhotoBinId",
                        column: x => x.PhotoBinId,
                        principalTable: "PhotoBins",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Businesses_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_PetAccounts_PetId",
                        column: x => x.PetId,
                        principalTable: "PetAccounts",
                        principalColumn: "PetAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetBios",
                columns: table => new
                {
                    PetBioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetInfo = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false),
                    Dislikes = table.Column<int>(nullable: false),
                    Hobbies = table.Column<string>(nullable: true),
                    PetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetBios", x => x.PetBioId);
                    table.ForeignKey(
                        name: "FK_PetBios_PetAccounts_PetId",
                        column: x => x.PetId,
                        principalTable: "PetAccounts",
                        principalColumn: "PetAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boardings",
                columns: table => new
                {
                    BoardingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boardings", x => x.BoardingId);
                    table.ForeignKey(
                        name: "FK_Boardings_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groomers",
                columns: table => new
                {
                    GroomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groomers", x => x.GroomerId);
                    table.ForeignKey(
                        name: "FK_Groomers_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Others",
                columns: table => new
                {
                    OtherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Others", x => x.OtherId);
                    table.ForeignKey(
                        name: "FK_Others_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTag = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceTagLine = table.Column<string>(nullable: true),
                    ServiceDescription = table.Column<string>(nullable: true),
                    PhotoBinId = table.Column<int>(nullable: false),
                    ServiceFurtherDescription = table.Column<string>(nullable: true),
                    ServiceDisplayOrder = table.Column<int>(nullable: false),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_PhotoBins_PhotoBinId",
                        column: x => x.PhotoBinId,
                        principalTable: "PhotoBins",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sitters",
                columns: table => new
                {
                    SitterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitters", x => x.SitterId);
                    table.ForeignKey(
                        name: "FK_Sitters_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                    table.ForeignKey(
                        name: "FK_Trainers_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vets",
                columns: table => new
                {
                    VetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vets", x => x.VetId);
                    table.ForeignKey(
                        name: "FK_Vets_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Immunizations",
                columns: table => new
                {
                    ImmunizationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImmunizationName = table.Column<string>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunizations", x => x.ImmunizationId);
                    table.ForeignKey(
                        name: "FK_Immunizations_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(nullable: true),
                    Instructions = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f8dd424-d7cf-44c8-8bca-380cd04d10c5", "3e83f447-2fe5-4ba7-822d-1244a89834b1", "Pet Owner", "PETOWNER" },
                    { "986d70ad-0a54-40ff-9dad-9f35059ff52e", "cd19fbec-ef8c-432b-b05d-300b967e02cc", "Business Owner", "BUSINESSOWNER" },
                    { "e4f00a75-bf1b-47fe-88d9-5f6d290348dc", "b3ed8c4f-683a-4eb6-9fb2-ca8a36cadade", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "PetAppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedFirstName", "NormalizedLastName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08985f88-f992-417e-ba80-c0324683ea91", 0, "1aa9c963-47d8-466c-b25c-c5dc783d6cfc", "Choua@choua.com", false, null, null, true, null, "CHOUA@CHOUA.COM", null, null, "CHOUA@CHOUA.COM", "AQAAAAEAACcQAAAAEL1tat7CzuP3E74HMHZg46VOIRV8zU2OrGlrZiiZ1lOE95v65PMnd45XoNFQRRepjQ==", "555-555-5555", false, "HWS6RX53NTMKWLVBRAQNCIKIFAUQ3FPK", false, "Choua@choua.com" },
                    { "5b339db7-fd08-4ffe-9467-4695dee7bd65", 0, "d1fdd1d6-884c-4d28-bd50-a6f32e6bfbe1", "Tim@tim.com", false, null, null, true, null, "TIM@TIM.COM", null, null, "TIM@TIM.COM", "AQAAAAEAACcQAAAAEG6euUT06GKNaSJe2Ksy0sRvdp+HJVJFBGPtqclwdvbu7S8IWdVhamthAkZPrLbTfQ==", "555-555-5555", false, "IKYVWNRLBUNDPYA2FTNX5TCFYZWCS7OO", false, "Tim@tim.com" },
                    { "d453a413-17b1-4f27-89d8-8f26af48f90b", 0, "9bcc49dc-5974-4ae5-8350-cb95c257d550", "Sam@sam.com", false, null, null, true, null, "SAM@SAM.COM", null, null, "SAM@SAM.COM", "AQAAAAEAACcQAAAAEGsIaD6NQJAT3n+lzCO4sEaNFKfc4NVzi8A6MoNnlCJsoehkvqPkbRTDbOjLr2tKbQ==", "555-555-5555", false, "4ZIGJCZL4JJEWK7PDYDN467AR3AVFJU7", false, "Sam@sam.com" },
                    { "d8195859-5968-48a5-b400-2afa2e29f775", 0, "8e3ea5b9-3cc2-4d52-8f2b-1b993dd7732e", "Milan@Milan.com", false, null, null, true, null, "MILAN@MILAN.COM", null, null, "MILAN@MILAN.COM", "AQAAAAEAACcQAAAAEPvPMaCo9UmPJVbeV+Btd3Y83X5Eyekn/hwXRbcfZEKrwB2welahQAJkL6ZjGZkeQw==", "555-555-5555", false, "4PHNLV4WVA7LCIA3S2QNDCYQGRCY6WJS", false, "Milan@Milan.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boardings_BusinessId",
                table: "Boardings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BusinessHourId",
                table: "Businesses",
                column: "BusinessHourId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_PhotoBinId",
                table: "Businesses",
                column: "PhotoBinId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_UserId",
                table: "Businesses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groomers_BusinessId",
                table: "Groomers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Immunizations_MedicalRecordId",
                table: "Immunizations",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PetId",
                table: "MedicalRecords",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalRecordId",
                table: "Medications",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Others_BusinessId",
                table: "Others",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAccounts_UserId",
                table: "PetAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAppRoleClaims_RoleId",
                table: "PetAppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "PetAppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PetAppUserClaims_UserId",
                table: "PetAppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAppUserLogins_UserId",
                table: "PetAppUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAppUserRoles_RoleId",
                table: "PetAppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "PetAppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "PetAppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PetBios_PetId",
                table: "PetBios",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessId",
                table: "Services",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PhotoBinId",
                table: "Services",
                column: "PhotoBinId");

            migrationBuilder.CreateIndex(
                name: "IX_Sitters_BusinessId",
                table: "Sitters",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_BusinessId",
                table: "Trainers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Vets_BusinessId",
                table: "Vets",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boardings");

            migrationBuilder.DropTable(
                name: "Groomers");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Immunizations");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "PetAppRoleClaims");

            migrationBuilder.DropTable(
                name: "PetAppUserClaims");

            migrationBuilder.DropTable(
                name: "PetAppUserLogins");

            migrationBuilder.DropTable(
                name: "PetAppUserRoles");

            migrationBuilder.DropTable(
                name: "PetAppUserTokens");

            migrationBuilder.DropTable(
                name: "PetBios");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "PetAppRoles");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "PetAccounts");

            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "PhotoBins");

            migrationBuilder.DropTable(
                name: "PetAppUsers");
        }
    }
}
