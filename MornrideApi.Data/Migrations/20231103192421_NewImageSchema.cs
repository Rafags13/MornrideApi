using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MornrideApi.Data.Migrations
{
    public partial class NewImageSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BannerImages",
                columns: table => new
                {
                    IdBannerImage = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Collection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageFrombannerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannerImages_Images_ImageFrombannerId",
                        column: x => x.ImageFrombannerId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BikeImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    BikeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HexColor = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
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
                    table.ForeignKey(
                        name: "FK_BikeImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannerImages_ImageFrombannerId",
                table: "BannerImages",
                column: "ImageFrombannerId");

            migrationBuilder.CreateIndex(
                name: "IX_BikeImages_BikeId",
                table: "BikeImages",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_BikeImages_ImageId",
                table: "BikeImages",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannerImages");

            migrationBuilder.DropTable(
                name: "BikeImages");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
