using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class Publisher_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "BOOKS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_PublisherId",
                table: "BOOKS",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKS_Publisher_PublisherId",
                table: "BOOKS",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKS_Publisher_PublisherId",
                table: "BOOKS");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_BOOKS_PublisherId",
                table: "BOOKS");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "BOOKS");
        }
    }
}
