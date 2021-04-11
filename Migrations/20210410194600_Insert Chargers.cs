using Microsoft.EntityFrameworkCore.Migrations;

namespace bellewsPhoneShop.Migrations
{
    public partial class InsertChargers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chargers",
                columns: table => new
                {
                    chargerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    chargerName = table.Column<string>(nullable: true),
                    chargerPort = table.Column<string>(nullable: true),
                    chargerPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chargers", x => x.chargerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chargers");
        }
    }
}
