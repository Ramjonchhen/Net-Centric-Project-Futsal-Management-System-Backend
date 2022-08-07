using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net_Centric_Project__Futsal_Management_System__Backend.Migrations
{
    public partial class futsalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Futsals",
                columns: table => new
                {
                    FutsalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FutsalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FutsalLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FutsalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FutsalStartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FutsalEndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BasePrice = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Futsals", x => x.FutsalId);
                    table.ForeignKey(
                        name: "FK_Futsals_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Futsals_AdminId",
                table: "Futsals",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Futsals");
        }
    }
}
