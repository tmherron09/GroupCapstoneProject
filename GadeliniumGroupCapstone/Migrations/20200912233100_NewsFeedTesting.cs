using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class NewsFeedTesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "2a5966ae-4315-4bd0-9661-f945ac60bad1");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "46c5c1df-8589-4d2a-9ed3-800e1fdbd3e1");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "ef15cfcb-ce7d-469c-946d-294668993abe");

            migrationBuilder.AddColumn<int>(
                name: "PhotoBinId",
                table: "PetAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99d2ab60-c42b-433a-ac88-1a0b5d82e882", "fdb22f88-29d8-4276-9b21-be8d8b71a810", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba022741-b3d2-4fb8-b8e4-0b86f78196db", "c00e1ccf-8561-4720-8815-07911b62f4d9", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0be4c03-a71b-42a0-86e0-cfb068c53543", "0ae5ce18-e51b-4dc9-9016-92fabc0fe3b2", "Admin", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_PetAccounts_PhotoBinId",
                table: "PetAccounts",
                column: "PhotoBinId");

            migrationBuilder.AddForeignKey(
                name: "FK_PetAccounts_PhotoBins_PhotoBinId",
                table: "PetAccounts",
                column: "PhotoBinId",
                principalTable: "PhotoBins",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetAccounts_PhotoBins_PhotoBinId",
                table: "PetAccounts");

            migrationBuilder.DropIndex(
                name: "IX_PetAccounts_PhotoBinId",
                table: "PetAccounts");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "99d2ab60-c42b-433a-ac88-1a0b5d82e882");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "ba022741-b3d2-4fb8-b8e4-0b86f78196db");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "d0be4c03-a71b-42a0-86e0-cfb068c53543");

            migrationBuilder.DropColumn(
                name: "PhotoBinId",
                table: "PetAccounts");

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef15cfcb-ce7d-469c-946d-294668993abe", "0e41a5f6-60ce-48dd-9b7b-bba70b7974fa", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a5966ae-4315-4bd0-9661-f945ac60bad1", "f0651580-e58a-4329-ab94-a6d18073c5c6", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46c5c1df-8589-4d2a-9ed3-800e1fdbd3e1", "8fbc83f2-b9c2-4bfe-8205-e2c96f84cecb", "Admin", "Admin" });
        }
    }
}
