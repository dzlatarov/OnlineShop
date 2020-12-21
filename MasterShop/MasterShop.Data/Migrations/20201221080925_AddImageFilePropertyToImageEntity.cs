using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterShop.Data.Migrations
{
    public partial class AddImageFilePropertyToImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Images");
        }
    }
}
