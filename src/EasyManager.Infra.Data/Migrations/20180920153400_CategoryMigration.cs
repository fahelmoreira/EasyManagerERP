using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyManager.Infra.Data.Migrations
{
    public partial class CategoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ChildCategoryId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "ProductBundle");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ChildCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ChildCategoryId",
                table: "Categories",
                newName: "ParentCategoryId");

            migrationBuilder.CreateTable(
                name: "ProductBundle<Product>",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBundle<Product>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBundle<Product>_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundle<Product>_ProductId",
                table: "ProductBundle<Product>",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "ProductBundle<Product>");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "Categories",
                newName: "ChildCategoryId");

            migrationBuilder.CreateTable(
                name: "ProductBundle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBundle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBundle_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ChildCategoryId",
                table: "Categories",
                column: "ChildCategoryId",
                unique: true,
                filter: "[ChildCategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBundle_ProductId",
                table: "ProductBundle",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ChildCategoryId",
                table: "Categories",
                column: "ChildCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
