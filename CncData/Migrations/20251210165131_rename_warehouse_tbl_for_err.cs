using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CncData.Migrations
{
    /// <inheritdoc />
    public partial class rename_warehouse_tbl_for_err : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Sheets_SheetId",
                table: "Warehouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouse_SheetId",
                table: "Warehouses",
                newName: "IX_Warehouses_SheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Sheets_SheetId",
                table: "Warehouses",
                column: "SheetId",
                principalTable: "Sheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Sheets_SheetId",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.RenameIndex(
                name: "IX_Warehouses_SheetId",
                table: "Warehouse",
                newName: "IX_Warehouse_SheetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Sheets_SheetId",
                table: "Warehouse",
                column: "SheetId",
                principalTable: "Sheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
