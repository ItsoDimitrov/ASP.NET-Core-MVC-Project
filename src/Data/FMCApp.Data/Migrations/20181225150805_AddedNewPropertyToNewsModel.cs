using Microsoft.EntityFrameworkCore.Migrations;

namespace FMCApp.Data.Migrations
{
    public partial class AddedNewPropertyToNewsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Newses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Newses");
        }
    }
}
