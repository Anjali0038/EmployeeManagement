using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class LeavedateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Leave",
                newName: "EmployeeName");

            migrationBuilder.AddColumn<DateTime>(
                name: "LeaveDate",
                table: "Leave",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeaveDate",
                table: "Leave");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Leave",
                newName: "FirstName");
        }
    }
}
