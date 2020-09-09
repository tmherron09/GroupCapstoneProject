using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class MigrateToNewModel : Migration
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
                name: "Buisnesses",
                columns: table => new
                {
                    BusinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buisnesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Buisnesses_PetAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PetAppUsers",
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
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f38a293-811c-40e7-97f9-c78111c5429d", "b6410795-3b3d-471d-9b6f-71aa6ea3ab75", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b2bcc9e-05e1-4a0e-96d9-66773fbe5558", "e6bc673a-c54d-4715-a543-ca3146fc298f", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b33bb32c-806e-4dae-83fd-8611736e6eb9", "6c0169f7-80e8-49ec-acfb-b2de2791d61c", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Boardings_BusinessId",
                table: "Boardings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Buisnesses_UserId",
                table: "Buisnesses",
                column: "UserId");

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
                name: "MedicalRecords");

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
                name: "PhotoBins");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "PetAppRoles");

            migrationBuilder.DropTable(
                name: "PetAccounts");

            migrationBuilder.DropTable(
                name: "Buisnesses");

            migrationBuilder.DropTable(
                name: "PetAppUsers");
        }
    }
}
