using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKS_Publisher_PublisherId",
                table: "BOOKS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "PUBLISHERS");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BOOKS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PUBLISHERS",
                table: "PUBLISHERS",
                column: "PublisherId");

            migrationBuilder.CreateTable(
                name: "AUTHORS",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORS", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BOOKS_AUTHORS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS_AUTHORS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOOKS_AUTHORS_AUTHORS_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AUTHORS",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BOOKS_AUTHORS_BOOKS_BookId",
                        column: x => x.BookId,
                        principalTable: "BOOKS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_AUTHORS_AuthorId",
                table: "BOOKS_AUTHORS",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BOOKS_AUTHORS_BookId",
                table: "BOOKS_AUTHORS",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKS_PUBLISHERS_PublisherId",
                table: "BOOKS",
                column: "PublisherId",
                principalTable: "PUBLISHERS",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOOKS_PUBLISHERS_PublisherId",
                table: "BOOKS");

            migrationBuilder.DropTable(
                name: "BOOKS_AUTHORS");

            migrationBuilder.DropTable(
                name: "AUTHORS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PUBLISHERS",
                table: "PUBLISHERS");

            migrationBuilder.RenameTable(
                name: "PUBLISHERS",
                newName: "Publisher");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BOOKS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BOOKS_Publisher_PublisherId",
                table: "BOOKS",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
