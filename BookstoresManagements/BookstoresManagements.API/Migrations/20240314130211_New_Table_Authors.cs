using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoresManagements.API.Migrations
{
    /// <inheritdoc />
    public partial class NewTableAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAuthor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
