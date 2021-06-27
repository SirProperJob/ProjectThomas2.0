using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectThomas.Data.Migrations
{
    public partial class CarouselImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarouselImage",
                columns: table => new
                {
                    CarouselImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    altString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselImage", x => x.CarouselImageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarouselImage");
        }
    }
}
