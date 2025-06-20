using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowedByUserRelationUpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_BorrowedByUserId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_BorrowedByUserId",
                table: "Books",
                column: "BorrowedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_BorrowedByUserId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_BorrowedByUserId",
                table: "Books",
                column: "BorrowedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
