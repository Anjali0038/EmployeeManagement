using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class Leavechangessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Leave",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Leave_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Leave_Id",
                table: "AspNetUsers",
                column: "Leave_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Leave_Leave_Id",
                table: "AspNetUsers",
                column: "Leave_Id",
                principalTable: "Leave",
                principalColumn: "Leave_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Leave_Leave_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Leave_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "Leave_Id",
                table: "AspNetUsers");
        }
    }
}
