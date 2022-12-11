using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Whatch.Migrations
{
    public partial class fixcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RealeaseDate",
                table: "Films",
                newName: "ReleaseDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Films",
                newName: "RealeaseDate");
        }
    }
}
