using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogAppCore.Migrations
{
    public partial class blog_table_imagename_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Blogs");
        }
    }
}
