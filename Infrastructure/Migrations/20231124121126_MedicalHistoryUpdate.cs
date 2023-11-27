using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MedicalHistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                schema: "Base",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_MedicalHistoryId",
                schema: "Base",
                table: "Appointment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                column: "MedicalHistoryId",
                unique: true,
                filter: "[MedicalHistoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                column: "MedicalHistoryId",
                principalSchema: "Base",
                principalTable: "MedicalHistory",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                schema: "Base",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_MedicalHistoryId",
                schema: "Base",
                table: "Appointment");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                column: "MedicalHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_MedicalHistory_MedicalHistoryId",
                schema: "Base",
                table: "Appointment",
                column: "MedicalHistoryId",
                principalSchema: "Base",
                principalTable: "MedicalHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
