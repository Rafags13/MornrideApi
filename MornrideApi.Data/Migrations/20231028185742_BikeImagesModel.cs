using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MornrideApi.Data.Migrations
{
    public partial class BikeImagesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HexColor = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    FullBike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontBike = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontWheel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackWheel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BikeImages_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeImages_BikeId",
                table: "BikeImages",
                column: "BikeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeImages");
        }
    }
}
