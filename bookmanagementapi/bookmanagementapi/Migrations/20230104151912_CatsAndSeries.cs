using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookManagement.Migrations
{
    /// <inheritdoc />
    public partial class CatsAndSeries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "categoryid",
                table: "books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "seriesid",
                table: "books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_series", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "authorseries",
                columns: table => new
                {
                    authorsid = table.Column<long>(type: "bigint", nullable: false),
                    seriesid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authorseries", x => new { x.authorsid, x.seriesid });
                    table.ForeignKey(
                        name: "fk_authorseries_authors_authorsid",
                        column: x => x.authorsid,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_authorseries_series_seriesid",
                        column: x => x.seriesid,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_categoryid",
                table: "books",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "ix_books_seriesid",
                table: "books",
                column: "seriesid");

            migrationBuilder.CreateIndex(
                name: "ix_authorseries_seriesid",
                table: "authorseries",
                column: "seriesid");

            migrationBuilder.AddForeignKey(
                name: "fk_books_category_categoryid",
                table: "books",
                column: "categoryid",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_series_seriesid",
                table: "books",
                column: "seriesid",
                principalTable: "series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_category_categoryid",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "fk_books_series_seriesid",
                table: "books");

            migrationBuilder.DropTable(
                name: "authorseries");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.DropIndex(
                name: "ix_books_categoryid",
                table: "books");

            migrationBuilder.DropIndex(
                name: "ix_books_seriesid",
                table: "books");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "books");

            migrationBuilder.DropColumn(
                name: "seriesid",
                table: "books");
        }
    }
}
