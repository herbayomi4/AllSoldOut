using Microsoft.EntityFrameworkCore.Migrations;

namespace AllSoldOut.Migrations
{
    public partial class FreshStart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@admin",
                column: "password",
                value: "$MYHASH$V1$10000$h1WfFtpjhzSu7kbS3ZGuVP6FpreCfp48jij2COdWPm4JEeLt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: "admin@admin",
                column: "password",
                value: "admin1234");
        }
    }
}
