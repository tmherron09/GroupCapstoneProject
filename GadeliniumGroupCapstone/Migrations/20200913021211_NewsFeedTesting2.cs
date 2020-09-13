using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class NewsFeedTesting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a51b686d-1220-4ddb-a38f-06ab4a9771a2", "8d475566-ec84-473f-b4ad-9fe59eb91e62", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca1370da-7c07-4553-a657-94f11ccf834a", "bd52ff0c-4b7e-4196-88f5-1233af122a4a", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c81c5485-66fd-48b8-abe8-dee06c4870be", "af1f1c22-1a21-4c66-986c-ec99d60e3b8b", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "a51b686d-1220-4ddb-a38f-06ab4a9771a2");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "c81c5485-66fd-48b8-abe8-dee06c4870be");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "ca1370da-7c07-4553-a657-94f11ccf834a");

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
        }
    }
}
