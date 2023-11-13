using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MornrideApi.Data.Migrations
{
    public partial class UpdatingBannerImageRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerImages_Images_ImageFrombannerId",
                table: "BannerImages");

            migrationBuilder.DropIndex(
                name: "IX_BannerImages_ImageFrombannerId",
                table: "BannerImages");

            migrationBuilder.DropColumn(
                name: "ImageFrombannerId",
                table: "BannerImages");

            migrationBuilder.RenameColumn(
                name: "IdBannerImage",
                table: "BannerImages",
                newName: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerImages_ImageId",
                table: "BannerImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BannerImages_Images_ImageId",
                table: "BannerImages",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerImages_Images_ImageId",
                table: "BannerImages");

            migrationBuilder.DropIndex(
                name: "IX_BannerImages_ImageId",
                table: "BannerImages");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "BannerImages",
                newName: "IdBannerImage");

            migrationBuilder.AddColumn<int>(
                name: "ImageFrombannerId",
                table: "BannerImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerImages_ImageFrombannerId",
                table: "BannerImages",
                column: "ImageFrombannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BannerImages_Images_ImageFrombannerId",
                table: "BannerImages",
                column: "ImageFrombannerId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
