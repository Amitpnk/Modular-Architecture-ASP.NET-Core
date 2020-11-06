using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HA.Adapter.Persistence.Migrations.Application
{
    public partial class InitialcommitApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("75f1b113-b17a-4203-ba52-44f77fe67977"), "IRD Deal 123", "IRD" });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("a1bb0bb1-bd10-4de9-b03b-60486102f85b"), "IRD Deal 456", "IRD" });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("8e0ca577-3dd6-496a-9f44-9bf1a3d8c16b"), "IRD Deal 789", "IRD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
