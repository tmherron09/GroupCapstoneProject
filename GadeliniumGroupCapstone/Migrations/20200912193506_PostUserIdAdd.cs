using Microsoft.EntityFrameworkCore.Migrations;

namespace GadeliniumGroupCapstone.Migrations
{
    public partial class PostUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "27da9b71-62b6-485d-886b-3dc8e490f82b");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "543c73a3-5a7e-41b0-a114-efc317a12866");

            migrationBuilder.DeleteData(
                table: "PetAppRoles",
                keyColumn: "Id",
                keyValue: "86f131ff-33d7-4670-8969-61f7714a4545");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosterId = table.Column<int>(nullable: false),
                    PosterName = table.Column<string>(nullable: true),
                    PostTitle = table.Column<string>(nullable: true),
                    PostContent = table.Column<string>(nullable: true),
                    PhotoBinId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_PhotoBins_PhotoBinId",
                        column: x => x.PhotoBinId,
                        principalTable: "PhotoBins",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostUsers",
                columns: table => new
                {
                    PostUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    IsLiked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUsers", x => x.PostUserId);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PhotoBinId",
                table: "Posts",
                column: "PhotoBinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostUsers");

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

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27da9b71-62b6-485d-886b-3dc8e490f82b", "239c2de8-c454-43ef-9ff7-fea3aa54f90b", "Pet Owner", "PETOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "543c73a3-5a7e-41b0-a114-efc317a12866", "26966cdf-3036-4143-92ce-8af5c339da40", "Business Owner", "BUSINESSOWNER" });

            migrationBuilder.InsertData(
                table: "PetAppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86f131ff-33d7-4670-8969-61f7714a4545", "b99719c2-5f38-4fd4-b196-72e791f7deb5", "Admin", "Admin" });
        }
    }
}
