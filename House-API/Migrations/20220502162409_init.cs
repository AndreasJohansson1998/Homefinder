using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace House_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HousingType = table.Column<int>(type: "INTEGER", nullable: false),
                    FormAssignment = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    LivingArea = table.Column<int>(type: "INTEGER", nullable: false),
                    YardArea = table.Column<int>(type: "INTEGER", nullable: true),
                    GrossArea = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    RoomAmount = table.Column<float>(type: "REAL", nullable: false),
                    ConstructionYear = table.Column<int>(type: "INTEGER", nullable: false),
                    VisitingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MonthlyFee = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
