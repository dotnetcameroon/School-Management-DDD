using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdminIdForeignKeyToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Student_AdminId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Student_AdminId",
                table: "Users",
                column: "Student_AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_Student_AdminId",
                table: "Users",
                column: "Student_AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_Student_AdminId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Student_AdminId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Student_AdminId",
                table: "Users");
        }
    }
}
