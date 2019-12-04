using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Encryptor.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("cb5cad85-6c33-4fc6-90be-4b5cfebe29ad"), "Vlad", "G", "passwD." },
                    { new Guid("23eab257-d843-4128-aeda-46176e7f8c26"), "Easy", "E", "EE" },
                    { new Guid("f8192112-2f3b-4800-be27-7503127ac5db"), "Unknown", "", "nooasswd" },
                    { new Guid("a318fc34-856b-4c71-8fd4-bdf7ed0df577"), "Inkognito", ";)", "lolHz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
