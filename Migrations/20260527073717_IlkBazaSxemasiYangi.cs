using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiApp.Migrations
{
    /// <inheritdoc />
    public partial class IlkBazaSxemasiYangi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haydovchilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ismi = table.Column<string>(type: "TEXT", nullable: true),
                    MashinaRaqami = table.Column<string>(type: "TEXT", nullable: true),
                    Holati = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haydovchilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mijozlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ismi = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mijozlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyurtmalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Qayerdan = table.Column<string>(type: "TEXT", nullable: true),
                    Qayerga = table.Column<string>(type: "TEXT", nullable: true),
                    Narx = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sana = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MijozId = table.Column<int>(type: "INTEGER", nullable: false),
                    HaydovchiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyurtmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyurtmalar_Haydovchilar_HaydovchiId",
                        column: x => x.HaydovchiId,
                        principalTable: "Haydovchilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Buyurtmalar_Mijozlar_MijozId",
                        column: x => x.MijozId,
                        principalTable: "Mijozlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyurtmalar_HaydovchiId",
                table: "Buyurtmalar",
                column: "HaydovchiId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyurtmalar_MijozId",
                table: "Buyurtmalar",
                column: "MijozId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyurtmalar");

            migrationBuilder.DropTable(
                name: "Haydovchilar");

            migrationBuilder.DropTable(
                name: "Mijozlar");
        }
    }
}
