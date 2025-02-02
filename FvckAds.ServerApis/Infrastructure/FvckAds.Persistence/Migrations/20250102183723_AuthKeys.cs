using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FvckAds.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuthKeys_Key",
                table: "AuthKeys",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AuthKeys_Key",
                table: "AuthKeys");
        }
    }
}
