using Microsoft.EntityFrameworkCore.Migrations;

namespace bellewsPhoneShop.Migrations
{
    public partial class CaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    caseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caseName = table.Column<string>(nullable: true),
                    casePrice = table.Column<float>(nullable: false),
                    caseColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.caseId);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
