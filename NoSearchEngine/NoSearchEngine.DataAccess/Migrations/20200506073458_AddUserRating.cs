using Microsoft.EntityFrameworkCore.Migrations;

namespace NoSearchEngine.DataAccess.Migrations
{
    public partial class AddUserRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resource",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resource",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_IsApproved_Description",
                table: "Resource",
                columns: new[] { "IsApproved", "Description" });

            migrationBuilder.CreateIndex(
                name: "IX_Resource_IsApproved_Url",
                table: "Resource",
                columns: new[] { "IsApproved", "Url" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resource_IsApproved_Description",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_Resource_IsApproved_Url",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Resource",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
