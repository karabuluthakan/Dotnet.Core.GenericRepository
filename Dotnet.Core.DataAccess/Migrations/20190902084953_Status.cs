using Microsoft.EntityFrameworkCore.Migrations;

namespace Dotnet.Core.DataAccess.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "regions",
                maxLength: 1,
                nullable: false,
                defaultValue: 1)
                .Annotation("Npgsql:Comment", "Active=1(Default),Passive=2,Hold=3,Done=4,Deleted=5");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "countries",
                maxLength: 1,
                nullable: false,
                defaultValue: 1)
                .Annotation("Npgsql:Comment", "Active=1(Default),Passive=2,Hold=3,Done=4,Deleted=5");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "continentals",
                maxLength: 1,
                nullable: false,
                defaultValue: 1)
                .Annotation("Npgsql:Comment", "Active=1(Default),Passive=2,Hold=3,Done=4,Deleted=5");

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "cities",
                maxLength: 1,
                nullable: false,
                defaultValue: 1)
                .Annotation("Npgsql:Comment", "Active=1(Default),Passive=2,Hold=3,Done=4,Deleted=5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "regions");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "countries");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "continentals");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "cities");
        }
    }
}
