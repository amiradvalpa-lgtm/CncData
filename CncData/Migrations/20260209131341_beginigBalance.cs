using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CncData.Migrations
{
    /// <inheritdoc />
    public partial class beginigBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BalanceType",
                table: "Customers",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceType",
                table: "Customers");
        }
    }
}
