using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class secondcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "5c41ff0b-1eb4-4bbf-ab78-e8883708f666");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "7ee1ba72-3a8f-41c3-b0ba-d81dc3c538a0");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "d040f34b-4b0a-4159-902d-49f78097308f");

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "973e869b-ffc8-47be-899a-bf3e9e14cc2f", "1f1dab6e-303d-405b-9ea6-9d706b0b4233", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "034499bd-4caa-4834-ae6a-adb33e5473df", "25456ae4-ac68-4887-869f-bd34ce9bc1c3", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d1e397d-e558-47b7-a701-2631c23fe519", "c125f572-77f1-41e4-8411-c01401b66150", "Admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "034499bd-4caa-4834-ae6a-adb33e5473df");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "3d1e397d-e558-47b7-a701-2631c23fe519");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "973e869b-ffc8-47be-899a-bf3e9e14cc2f");

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ee1ba72-3a8f-41c3-b0ba-d81dc3c538a0", "ea5289ff-a044-4af9-ba81-3309b0ea7ca5", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d040f34b-4b0a-4159-902d-49f78097308f", "5dbabe3a-e5a3-4eab-aaf4-6a8a38d3733b", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c41ff0b-1eb4-4bbf-ab78-e8883708f666", "79bf9fd6-6acc-4ef4-acd7-11400c0891d0", "Admin", "Admin" });
        }
    }
}
