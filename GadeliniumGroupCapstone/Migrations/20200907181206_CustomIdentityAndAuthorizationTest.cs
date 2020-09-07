using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class CustomIdentityAndAuthorizationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SiteRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteUsers",
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
                    SecondaryEmail = table.Column<string>(nullable: true),
                    NormalizedSecondaryEmail = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HasPet = table.Column<bool>(nullable: false),
                    HasMultiplePet = table.Column<bool>(nullable: false),
                    HasBusiness = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
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
                name: "SiteRoleClaims",
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
                    table.PrimaryKey("PK_SiteRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteRoleClaims_SiteRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SiteRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buisnesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    SiteUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buisnesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Buisnesses_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PetAccounts",
                columns: table => new
                {
                    PetAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Breed = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    PetName = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    AnimalType = table.Column<string>(nullable: true),
                    PetPhone = table.Column<string>(nullable: true),
                    SiteUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAccounts", x => x.PetAccountId);
                    table.ForeignKey(
                        name: "FK_PetAccounts_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiteUserClaims",
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
                    table.PrimaryKey("PK_SiteUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteUserClaims_SiteUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_SiteUserLogins_SiteUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SiteUserRoles_SiteRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SiteRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteUserRoles_SiteUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_SiteUserTokens_SiteUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id",
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
                        name: "FK_Boardings_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
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
                        name: "FK_Groomers_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
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
                        name: "FK_Others_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
                        principalColumn: "BusinessId",
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
                        name: "FK_Sitters_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
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
                        name: "FK_Trainers_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
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
                        name: "FK_Vets_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<int>(nullable: false),
                    SiteUserId = table.Column<string>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Buisnesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Buisnesses",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_PetAccounts_PetId",
                        column: x => x.PetId,
                        principalTable: "PetAccounts",
                        principalColumn: "PetAccountId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "SiteRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "34fca639-db9c-4858-b64b-176970658b9a", "46cc4c44-e31c-429b-9ffe-833177398540", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "SiteRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b30b07ca-2bdd-4238-bd30-434bacb8af9f", "d9c333f8-025a-44e7-942e-5eb461c583cb", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BusinessId",
                table: "Accounts",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PetId",
                table: "Accounts",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Boardings_BusinessId",
                table: "Boardings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Buisnesses_SiteUserId",
                table: "Buisnesses",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Groomers_BusinessId",
                table: "Groomers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PetId",
                table: "MedicalRecords",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Others_BusinessId",
                table: "Others",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAccounts_SiteUserId",
                table: "PetAccounts",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetBios_PetId",
                table: "PetBios",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteRoleClaims_RoleId",
                table: "SiteRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "SiteRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUserClaims_UserId",
                table: "SiteUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUserLogins_UserId",
                table: "SiteUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteUserRoles_RoleId",
                table: "SiteUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "SiteUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "SiteUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Boardings");

            migrationBuilder.DropTable(
                name: "Groomers");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Others");

            migrationBuilder.DropTable(
                name: "PetBios");

            migrationBuilder.DropTable(
                name: "SiteRoleClaims");

            migrationBuilder.DropTable(
                name: "SiteUserClaims");

            migrationBuilder.DropTable(
                name: "SiteUserLogins");

            migrationBuilder.DropTable(
                name: "SiteUserRoles");

            migrationBuilder.DropTable(
                name: "SiteUserTokens");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "PetAccounts");

            migrationBuilder.DropTable(
                name: "SiteRoles");

            migrationBuilder.DropTable(
                name: "Buisnesses");

            migrationBuilder.DropTable(
                name: "SiteUsers");
        }
    }
}
