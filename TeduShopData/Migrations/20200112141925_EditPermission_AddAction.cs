using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduShopData.Migrations
{
    public partial class EditPermission_AddAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "Permissions",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Code = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionsInFunctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<int>(nullable: false),
                    FunctionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionsInFunctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Actions_dbo.ActionsInFunction_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Funtions_dbo.ActionsInFunction_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ActionId",
                table: "Permissions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsInFunctions_ActionId",
                table: "ActionsInFunctions",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsInFunctions_FunctionId",
                table: "ActionsInFunctions",
                column: "FunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Permissions_dbo.Actions_ActionId",
                table: "Permissions",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Permissions_dbo.Actions_ActionId",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "ActionsInFunctions");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ActionId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Permissions");
        }
    }
}
