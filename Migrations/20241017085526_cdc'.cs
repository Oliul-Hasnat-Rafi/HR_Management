using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hr_task.Migrations
{
    /// <inheritdoc />
    public partial class cdc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "desigName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "shiftName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "desigName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "shiftName",
                table: "Employees");
        }
    }
}
