using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CncData.Migrations
{
    /// <inheritdoc />
    public partial class modifySomeTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CNCPrice",
                table: "Sheets",
                newName: "CNCPriceBySheet");

            migrationBuilder.AddColumn<double>(
                name: "CNCPriceByMeter",
                table: "Sheets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CNCPriceByPice",
                table: "Sheets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sheets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Receipts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SheetCount",
                table: "OrderDetails",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BankAccounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNCPriceByMeter",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "CNCPriceByPice",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "SheetCount",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "CNCPriceBySheet",
                table: "Sheets",
                newName: "CNCPrice");
        }
    }
}
