using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MornrideApi.Data.Migrations
{
    public partial class AddImagePositionToBikeImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePosition",
                table: "BikeImages",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePosition",
                table: "BikeImages");
        }
    }
}
