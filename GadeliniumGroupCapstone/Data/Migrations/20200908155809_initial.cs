using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d14ec73-5c9d-41fc-8201-5145ddd68208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86758b8d-b03b-48aa-9619-12fff9ecbad8");

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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buisnesses", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Buisnesses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAccounts", x => x.PetAccountId);
                    table.ForeignKey(
                        name: "FK_PetAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43a817e0-e963-4e96-b602-45976c32ed7d", "badf5508-514f-4c00-b8c2-fa43e62b1fae", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a88c6e7-6e3f-4e9b-a153-480b8cc4148d", "8edc7996-fbda-457d-8ae0-b086567d2854", "Business Owner", "BUSINESSOWNER" });

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
                name: "PetBios");

            migrationBuilder.DropTable(
                name: "Sitters");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Vets");

            migrationBuilder.DropTable(
                name: "PetAccounts");

            migrationBuilder.DropTable(
                name: "Buisnesses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43a817e0-e963-4e96-b602-45976c32ed7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a88c6e7-6e3f-4e9b-a153-480b8cc4148d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86758b8d-b03b-48aa-9619-12fff9ecbad8", "7302ac1f-7025-47f5-95c8-419b9fbefd53", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6d14ec73-5c9d-41fc-8201-5145ddd68208", "1a214f5d-1dda-4eb7-86b2-75674e6a64d3", "Business Owner", "BUSINESSOWNER" });
        }
    }
}
