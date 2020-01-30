using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeduShopData.Migrations
{
    public partial class addDynamicAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    BackendType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeOptions_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueDateTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueDateTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueDatTime_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueDatTime_dbo.Attributes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueDecimals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueDecimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueDecimals_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueDecimals_dbo.Attributes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueInts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueInts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueInts_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueInts_dbo.Attributes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueText",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueText_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueText_dbo.Attributes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValueVarchars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValueVarchars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueVarchars_dbo.Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeValueVarchars_dbo.Attributes_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeOptionValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeOptionValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AttributeOptionValues_dbo.AttributeOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "AttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptions_AttributeId",
                table: "AttributeOptions",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeOptionValues_OptionId",
                table: "AttributeOptionValues",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueDateTimes_AttributeId",
                table: "AttributeValueDateTimes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueDateTimes_ProductId",
                table: "AttributeValueDateTimes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueDecimals_AttributeId",
                table: "AttributeValueDecimals",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueDecimals_ProductId",
                table: "AttributeValueDecimals",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueInts_AttributeId",
                table: "AttributeValueInts",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueInts_ProductId",
                table: "AttributeValueInts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueText_AttributeId",
                table: "AttributeValueText",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueText_ProductId",
                table: "AttributeValueText",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueVarchars_AttributeId",
                table: "AttributeValueVarchars",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValueVarchars_ProductId",
                table: "AttributeValueVarchars",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeOptionValues");

            migrationBuilder.DropTable(
                name: "AttributeValueDateTimes");

            migrationBuilder.DropTable(
                name: "AttributeValueDecimals");

            migrationBuilder.DropTable(
                name: "AttributeValueInts");

            migrationBuilder.DropTable(
                name: "AttributeValueText");

            migrationBuilder.DropTable(
                name: "AttributeValueVarchars");

            migrationBuilder.DropTable(
                name: "AttributeOptions");

            migrationBuilder.DropTable(
                name: "Attributes");
        }
    }
}
