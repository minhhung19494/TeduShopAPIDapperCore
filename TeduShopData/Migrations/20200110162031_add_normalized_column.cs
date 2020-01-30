using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduShopData.Migrations
{
    public partial class add_normalized_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AppUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AppUsers");
        }
    }
}
