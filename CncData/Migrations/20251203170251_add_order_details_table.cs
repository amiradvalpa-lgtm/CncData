using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CncData.Migrations
{
    /// <inheritdoc />
    public partial class add_order_details_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Sheets_SheetId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SheetId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CncCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CutLength",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CutWidth",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FinalSheetCost",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GrooveLength",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SheetId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Orders");

            migrationBuilder.AddColumn<double>(
                name: "CNCPrice",
                table: "Sheets",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    DetailName = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    SheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Supplier = table.Column<int>(type: "INTEGER", nullable: false),
                    CutLength = table.Column<double>(type: "REAL", nullable: false),
                    CutWidth = table.Column<double>(type: "REAL", nullable: false),
                    FinalSheetCost = table.Column<double>(type: "REAL", nullable: false),
                    GrooveLength = table.Column<double>(type: "REAL", nullable: false),
                    CncCost = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "Sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SheetId",
                table: "OrderDetails",
                column: "SheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CNCPrice",
                table: "Sheets");

            migrationBuilder.AddColumn<double>(
                name: "CncCost",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CutLength",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CutWidth",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FinalSheetCost",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GrooveLength",
                table: "Orders",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SheetId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Supplier",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SheetId",
                table: "Orders",
                column: "SheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Sheets_SheetId",
                table: "Orders",
                column: "SheetId",
                principalTable: "Sheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
