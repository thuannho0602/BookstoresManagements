using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookstoresManagements.API.Migrations
{
    /// <inheritdoc />
    public partial class EditTablecolumEmailPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Publisher",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Publisher");
        }
    }
}
