using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class Department_Added3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employees_Employee",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_Employee",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "Employee",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_Employee",
                table: "Department",
                column: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employees_Employee",
                table: "Department",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
