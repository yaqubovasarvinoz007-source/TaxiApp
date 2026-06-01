using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyurtmalar_Haydovchilar_HaydovchiId",
                table: "Buyurtmalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Buyurtmalar_Mijozlar_MijozId",
                table: "Buyurtmalar");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Mijozlar",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Mijozlar",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MashinaRaqami",
                table: "Haydovchilar",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Haydovchilar",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Holati",
                table: "Haydovchilar",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Qayerga",
                table: "Buyurtmalar",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Qayerdan",
                table: "Buyurtmalar",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Narx",
                table: "Buyurtmalar",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyurtmalar_Haydovchilar_HaydovchiId",
                table: "Buyurtmalar",
                column: "HaydovchiId",
                principalTable: "Haydovchilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buyurtmalar_Mijozlar_MijozId",
                table: "Buyurtmalar",
                column: "MijozId",
                principalTable: "Mijozlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyurtmalar_Haydovchilar_HaydovchiId",
                table: "Buyurtmalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Buyurtmalar_Mijozlar_MijozId",
                table: "Buyurtmalar");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Mijozlar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Mijozlar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MashinaRaqami",
                table: "Haydovchilar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Ismi",
                table: "Haydovchilar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Holati",
                table: "Haydovchilar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Qayerga",
                table: "Buyurtmalar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Qayerdan",
                table: "Buyurtmalar",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "Narx",
                table: "Buyurtmalar",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyurtmalar_Haydovchilar_HaydovchiId",
                table: "Buyurtmalar",
                column: "HaydovchiId",
                principalTable: "Haydovchilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buyurtmalar_Mijozlar_MijozId",
                table: "Buyurtmalar",
                column: "MijozId",
                principalTable: "Mijozlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
