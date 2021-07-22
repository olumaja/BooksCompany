using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.DataAccess.Migrations
{
    public partial class ReAddeddAuthorizedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorizedCompany",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuthorizedCompany",
                table: "Companies");
        }
    }
}
