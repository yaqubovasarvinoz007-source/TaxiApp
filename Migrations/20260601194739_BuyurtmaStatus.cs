using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiApp.Migrations
{
    /// <inheritdoc />
    public partial class BuyurtmaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Holat",
                table: "Buyurtmalar",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Holat",
                table: "Buyurtmalar");
        }
    }
}
