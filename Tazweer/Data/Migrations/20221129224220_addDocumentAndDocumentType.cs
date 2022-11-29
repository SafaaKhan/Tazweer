using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tazweer.Data.Migrations
{
    public partial class addDocumentAndDocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentsType",
                columns: table => new
                {
                    DocumentsTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsType", x => x.DocumentsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<int>(type: "int", nullable: false),
                    Filetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filecon = table.Column<int>(type: "int", nullable: false),
                    Filesize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passportId = table.Column<int>(type: "int", nullable: false),
                    DocumentsTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentsId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentsType_DocumentsTypeId",
                        column: x => x.DocumentsTypeId,
                        principalTable: "DocumentsType",
                        principalColumn: "DocumentsTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_LostPassportInformation_passportId",
                        column: x => x.passportId,
                        principalTable: "LostPassportInformation",
                        principalColumn: "passportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentsTypeId",
                table: "Documents",
                column: "DocumentsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_passportId",
                table: "Documents",
                column: "passportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentsType");
        }
    }
}
