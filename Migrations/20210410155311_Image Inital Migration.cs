using Microsoft.EntityFrameworkCore.Migrations;

namespace bellewsPhoneShop.Migrations
{
    public partial class ImageInitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "casePrice",
                table: "Cases",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.AlterColumn<float>(
                name: "casePrice",
                table: "Cases",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
