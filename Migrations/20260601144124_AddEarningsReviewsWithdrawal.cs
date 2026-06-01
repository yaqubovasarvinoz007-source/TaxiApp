using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiApp.Migrations
{
    /// <inheritdoc />
    public partial class AddEarningsReviewsWithdrawal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HaydovchiDaromadilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HaydovchiId = table.Column<int>(type: "INTEGER", nullable: false),
                    BugunDaromad = table.Column<decimal>(type: "TEXT", nullable: false),
                    JamiDaromad = table.Column<decimal>(type: "TEXT", nullable: false),
                    YechilganPul = table.Column<decimal>(type: "TEXT", nullable: false),
                    HisobdagiPul = table.Column<decimal>(type: "TEXT", nullable: false),
                    YolovchiSoni = table.Column<int>(type: "INTEGER", nullable: false),
                    Reyting = table.Column<double>(type: "REAL", nullable: false),
                    OxirigiYangilandi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HaydovchiDaromadilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HaydovchiDaromadilar_Haydovchilar_HaydovchiId",
                        column: x => x.HaydovchiId,
                        principalTable: "Haydovchilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MijozSharhlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HaydovchiId = table.Column<int>(type: "INTEGER", nullable: false),
                    MijozId = table.Column<int>(type: "INTEGER", nullable: false),
                    Reyting = table.Column<int>(type: "INTEGER", nullable: false),
                    Sharh = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Sana = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MijozSharhlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MijozSharhlari_Haydovchilar_HaydovchiId",
                        column: x => x.HaydovchiId,
                        principalTable: "Haydovchilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MijozSharhlari_Mijozlar_MijozId",
                        column: x => x.MijozId,
                        principalTable: "Mijozlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PulYechishlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HaydovchiId = table.Column<int>(type: "INTEGER", nullable: false),
                    Summa = table.Column<decimal>(type: "TEXT", nullable: false),
                    Holati = table.Column<string>(type: "TEXT", nullable: true),
                    YechishSana = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TasdiqlanganSana = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Izoh = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PulYechishlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PulYechishlari_Haydovchilar_HaydovchiId",
                        column: x => x.HaydovchiId,
                        principalTable: "Haydovchilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HaydovchiDaromadilar_HaydovchiId",
                table: "HaydovchiDaromadilar",
                column: "HaydovchiId");

            migrationBuilder.CreateIndex(
                name: "IX_MijozSharhlari_HaydovchiId",
                table: "MijozSharhlari",
                column: "HaydovchiId");

            migrationBuilder.CreateIndex(
                name: "IX_MijozSharhlari_MijozId",
                table: "MijozSharhlari",
                column: "MijozId");

            migrationBuilder.CreateIndex(
                name: "IX_PulYechishlari_HaydovchiId",
                table: "PulYechishlari",
                column: "HaydovchiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HaydovchiDaromadilar");

            migrationBuilder.DropTable(
                name: "MijozSharhlari");

            migrationBuilder.DropTable(
                name: "PulYechishlari");
        }
    }
}
