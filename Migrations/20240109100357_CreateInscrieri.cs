using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect.Migrations
{
    public partial class CreateInscrieri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscriere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursID = table.Column<int>(type: "int", nullable: false),
                    TipBiletID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inscriere_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriere_Curs_CursID",
                        column: x => x.CursID,
                        principalTable: "Curs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriere_TipBilet_TipBiletID",
                        column: x => x.TipBiletID,
                        principalTable: "TipBilet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_ClientID",
                table: "Inscriere",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_CursID",
                table: "Inscriere",
                column: "CursID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_TipBiletID",
                table: "Inscriere",
                column: "TipBiletID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriere");
        }
    }
}
