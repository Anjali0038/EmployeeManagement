using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class ModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employees_employeeId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                newName: "IX_Employees_Department");

            migrationBuilder.RenameColumn(
                name: "employeeId",
                table: "Department",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Department_employeeId",
                table: "Department",
                newName: "IX_Department_Employee");

            migrationBuilder.AddColumn<int>(
                name: "Attendance",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Report_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<long>(type: "bigint", nullable: false),
                    Employee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Report_Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Employees_Employee",
                        column: x => x.Employee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Attendance",
                table: "Employees",
                column: "Attendance");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_Employee",
                table: "Attendances",
                column: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employees_Employee",
                table: "Department",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Attendances_Attendance",
                table: "Employees",
                column: "Attendance",
                principalTable: "Attendances",
                principalColumn: "Report_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_Department",
                table: "Employees",
                column: "Department",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employees_Employee",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Attendances_Attendance",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_Department",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Attendance",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Attendance",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Department",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_Department",
                table: "Employees",
                newName: "IX_Employees_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "Department",
                newName: "employeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_Employee",
                table: "Department",
                newName: "IX_Department_employeeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employees_employeeId",
                table: "Department",
                column: "employeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
