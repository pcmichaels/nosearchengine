using Microsoft.EntityFrameworkCore.Migrations;

namespace NoSearchEngine.DataAccess.Migrations
{
    public partial class AddResourceUserMappingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ResourceId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceUser_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResourceUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUser_ResourceId",
                table: "ResourceUser",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUser_UserId",
                table: "ResourceUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceUser");
        }
    }
}
