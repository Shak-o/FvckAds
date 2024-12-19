using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FvckAds.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthKeysAlredyUsed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AlreadyUsed",
                table: "AuthKeys",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlreadyUsed",
                table: "AuthKeys");
        }
    }
}
