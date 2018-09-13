using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyManager.Infra.Data.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CredcardOperators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredcardOperators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReceiptNumber = table.Column<int>(nullable: false),
                    Serie = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ManufactureId = table.Column<Guid>(nullable: true),
                    DocumentData = table.Column<DateTime>(nullable: false),
                    DateEntry = table.Column<DateTime>(nullable: false),
                    Products = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    Observations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsBankAccount = table.Column<bool>(nullable: false),
                    BankId = table.Column<Guid>(nullable: true),
                    Agency = table.Column<int>(nullable: false),
                    Digit = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<int>(nullable: false),
                    Wallet = table.Column<int>(nullable: false),
                    Observations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DepartamentId = table.Column<Guid>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    DeliveryTime = table.Column<DateTime>(nullable: true),
                    ProductOrder = table.Column<string>(nullable: true),
                    Observations = table.Column<string>(nullable: true),
                    DiscountValue = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    DeliveryFee = table.Column<double>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Departaments_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PaymentType = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: true),
                    SendToFinatial = table.Column<bool>(nullable: false),
                    ConfirmationType = table.Column<int>(nullable: false),
                    StoreInterest = table.Column<double>(nullable: false),
                    FinanceInterest = table.Column<double>(nullable: false),
                    Fine = table.Column<double>(nullable: false),
                    DelayFine = table.Column<double>(nullable: false),
                    DelayFinePercentage = table.Column<double>(nullable: false),
                    BankFee = table.Column<double>(nullable: false),
                    CredcardOperatorId = table.Column<Guid>(nullable: true),
                    OperationFee = table.Column<double>(nullable: false),
                    InstallmentsMax = table.Column<int>(nullable: false),
                    InstallmentsInterval = table.Column<int>(nullable: false),
                    StartOnFirst = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_CredcardOperators_CredcardOperatorId",
                        column: x => x.CredcardOperatorId,
                        principalTable: "CredcardOperators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Financias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BudgetType = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<Guid>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Values = table.Column<double>(nullable: false),
                    InstallmentInformation = table.Column<string>(nullable: true),
                    Confirm = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financias_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankId",
                table: "BankAccounts",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Financias_PaymentMethodId",
                table: "Financias",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DepartamentId",
                table: "Orders",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_BankAccountId",
                table: "PaymentMethods",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CredcardOperatorId",
                table: "PaymentMethods",
                column: "CredcardOperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ManufactureId",
                table: "Purchases",
                column: "ManufactureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financias");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Departaments");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "CredcardOperators");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
