using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyManager.Infra.Data.Migrations
{
    public partial class ProductMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Manufactures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CorporateName",
                table: "Manufactures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Manufactures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndividualTaxpayerId",
                table: "Manufactures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Manufactures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Manufactures",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "Customers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorporateName",
                table: "Customers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CreditLimit",
                table: "Customers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiveEmail",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ChildCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesTables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Profit = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    InternalCode = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Immobilized = table.Column<double>(nullable: false),
                    Consumption = table.Column<double>(nullable: false),
                    Resale = table.Column<double>(nullable: false),
                    ResaleMin = table.Column<double>(nullable: false),
                    ResaleMax = table.Column<double>(nullable: false),
                    SalesTable = table.Column<string>(nullable: true),
                    OtherExpenses = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    SoldSeparately = table.Column<bool>(nullable: false),
                    Comission = table.Column<double>(nullable: false),
                    Observations = table.Column<string>(nullable: true),
                    Attributes = table.Column<string>(nullable: true),
                    ManufactureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductBundle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Amount = table.Column<double>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureId",
                table: "Products",
                column: "ManufactureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductBundle");

            migrationBuilder.DropTable(
                name: "SalesTables");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "CorporateName",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "IndividualTaxpayerId",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CorporateName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditLimit",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ReceiveEmail",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "Customers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
