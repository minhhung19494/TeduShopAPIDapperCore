using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduShopData.Migrations
{
    public partial class deleteDiscriminator_deletePermissionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanCreate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CanDelete",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CanRead",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "CanUpdate",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AppRoles");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "AppRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "AppRoles");

            migrationBuilder.AddColumn<bool>(
                name: "CanCreate",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanDelete",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanRead",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanUpdate",
                table: "Permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AppRoles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
