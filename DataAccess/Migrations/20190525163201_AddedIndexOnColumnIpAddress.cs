using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedIndexOnColumnIpAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "VotingGroups",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_VotingGroups_IpAddress",
                table: "VotingGroups",
                column: "IpAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VotingGroups_IpAddress",
                table: "VotingGroups");

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "VotingGroups",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
