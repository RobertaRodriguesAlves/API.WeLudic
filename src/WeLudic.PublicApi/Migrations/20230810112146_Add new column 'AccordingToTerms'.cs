using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    public partial class AddnewcolumnAccordingToTerms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AccordingToTerms",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccordingToTerms",
                table: "Users");
        }
    }
}
