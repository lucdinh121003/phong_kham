using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhongKhamOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BacSis_AspNetUsers_ApplicationUserId",
                table: "BacSis");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "BacSis",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BacSis_ApplicationUserId",
                table: "BacSis",
                newName: "IX_BacSis_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BacSis_AspNetUsers_UserId",
                table: "BacSis",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BacSis_AspNetUsers_UserId",
                table: "BacSis");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BacSis",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_BacSis_UserId",
                table: "BacSis",
                newName: "IX_BacSis_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BacSis_AspNetUsers_ApplicationUserId",
                table: "BacSis",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
