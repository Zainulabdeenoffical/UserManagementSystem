using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class TableColumnsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "User",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Frist_name",
                table: "User",
                newName: "First_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "user",
                newName: "Frist_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "ID");
        }
    }
}
