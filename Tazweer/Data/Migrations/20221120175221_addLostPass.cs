using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tazweer.Data.Migrations
{
    public partial class addLostPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LostPassportInformation",
                columns: table => new
                {
                    passportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassportOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dateofloss = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thecommandbasedonit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thenote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thereasonofdelete = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostPassportInformation", x => x.passportId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LostPassportInformation");
        }
    }
}
