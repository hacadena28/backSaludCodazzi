using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Patient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "block");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                schema: "Base",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "block",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SecondLastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DocumentType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Phone = table.Column<long>(type: "bigint", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Person_Id",
                        column: x => x.Id,
                        principalSchema: "block",
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                schema: "Base",
                table: "User",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Person_PersonId",
                schema: "Base",
                table: "User",
                column: "PersonId",
                principalSchema: "block",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Person_PersonId",
                schema: "Base",
                table: "User");

            migrationBuilder.DropTable(
                name: "Patient",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "block");

            migrationBuilder.DropIndex(
                name: "IX_User_PersonId",
                schema: "Base",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PersonId",
                schema: "Base",
                table: "User");
        }
    }
}
