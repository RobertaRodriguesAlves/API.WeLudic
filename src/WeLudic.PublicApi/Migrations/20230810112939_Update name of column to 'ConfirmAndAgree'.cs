using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeLudic.PublicApi.Migrations
{
    public partial class UpdatenameofcolumntoConfirmAndAgree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccordingToTerms",
                table: "Users",
                newName: "ConfirmAndAgree");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmAndAgree",
                table: "Users",
                newName: "AccordingToTerms");
        }
    }
}
