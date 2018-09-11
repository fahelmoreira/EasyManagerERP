using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyManager.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TradeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IndividualTaxpayerId = table.Column<string>(nullable: true),
                    CorporateTaxpayerId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
