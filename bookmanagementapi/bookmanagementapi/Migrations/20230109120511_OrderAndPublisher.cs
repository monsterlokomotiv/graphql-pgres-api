using BookManagement.Domain;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookManagement.Migrations
{
    /// <inheritdoc />
    public partial class OrderAndPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_category_categoryid",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "categories");

            migrationBuilder.AddColumn<long>(
                name: "publisherid",
                table: "books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "pk_categories",
                table: "categories",
                column: "id");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<OrderAddress>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publisher", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_publisherid",
                table: "books",
                column: "publisherid");

            migrationBuilder.CreateIndex(
                name: "ix_orders_id",
                table: "orders",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_categories_categoryid",
                table: "books",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_books_publisher_publisherid",
                table: "books",
                column: "publisherid",
                principalTable: "publisher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_categories_categoryid",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "fk_books_publisher_publisherid",
                table: "books");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "publisher");

            migrationBuilder.DropIndex(
                name: "ix_books_publisherid",
                table: "books");

            migrationBuilder.DropPrimaryKey(
                name: "pk_categories",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "publisherid",
                table: "books");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "category");

            migrationBuilder.AddPrimaryKey(
                name: "pk_category",
                table: "category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_category_categoryid",
                table: "books",
                column: "categoryid",
                principalTable: "category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
