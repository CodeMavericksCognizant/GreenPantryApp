using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenPantryApp.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                schema: "dbo",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                schema: "dbo",
                newName: "Foods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                schema: "dbo",
                table: "Food",
                column: "Id");
        }
    }
}
