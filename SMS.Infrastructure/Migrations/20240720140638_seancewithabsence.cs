using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seancewithabsence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "idSeance",
                table: "Absences",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_idSeance",
                table: "Absences",
                column: "idSeance");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Seances_idSeance",
                table: "Absences",
                column: "idSeance",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Seances_idSeance",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_idSeance",
                table: "Absences");

            migrationBuilder.AlterColumn<string>(
                name: "idSeance",
                table: "Absences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
