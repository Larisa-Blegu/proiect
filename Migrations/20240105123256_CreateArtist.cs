using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiect.Migrations
{
    public partial class CreateArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Curs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Curs",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Curs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curs_ArtistID",
                table: "Curs",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Curs_Artist_ArtistID",
                table: "Curs",
                column: "ArtistID",
                principalTable: "Artist",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curs_Artist_ArtistID",
                table: "Curs");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Curs_ArtistID",
                table: "Curs");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Curs");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Curs",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Curs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
