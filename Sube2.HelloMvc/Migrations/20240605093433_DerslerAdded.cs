using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class DerslerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler");

            migrationBuilder.RenameTable(
                name: "Dersler",
                newName: "tblDersler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDersler",
                table: "tblDersler",
                column: "Dersid");

            migrationBuilder.CreateTable(
                name: "OgrenciDersler",
                columns: table => new
                {
                    DerslerDersid = table.Column<int>(type: "int", nullable: false),
                    OgrencilerOgrenciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDersler", x => new { x.DerslerDersid, x.OgrencilerOgrenciId });
                    table.ForeignKey(
                        name: "FK_OgrenciDersler_tblDersler_DerslerDersid",
                        column: x => x.DerslerDersid,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDersler_tblOgrenciler_OgrencilerOgrenciId",
                        column: x => x.OgrencilerOgrenciId,
                        principalTable: "tblOgrenciler",
                        principalColumn: "OgrenciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDersler_OgrencilerOgrenciId",
                table: "OgrenciDersler",
                column: "OgrencilerOgrenciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDersler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDersler",
                table: "tblDersler");

            migrationBuilder.RenameTable(
                name: "tblDersler",
                newName: "Dersler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler",
                column: "Dersid");
        }
    }
}
