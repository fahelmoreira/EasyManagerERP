using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyManager.Infra.Data.Migrations
{
    public partial class ManufactureMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TradeName = table.Column<string>(nullable: true),
                    CorporateTaxpayerId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contacts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manufactures");
        }
    }
}
