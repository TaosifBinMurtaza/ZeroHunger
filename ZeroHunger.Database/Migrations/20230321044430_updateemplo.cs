using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZeroHunger.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateemplo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Employees");
        }
    }
}
