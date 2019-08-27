using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dotnet.Core.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "continentals",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_continentals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regions",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    continental_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regions", x => x.id);
                    table.ForeignKey(
                        name: "fk_regions_continentals_continental_id",
                        column: x => x.continental_id,
                        principalSchema: "public",
                        principalTable: "continentals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    region_id = table.Column<int>(nullable: false),
                    alpha_2_code = table.Column<string>(type: "varchar", maxLength: 2, nullable: false),
                    alpha_3_code = table.Column<string>(type: "varchar", maxLength: 3, nullable: false),
                    un_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                    table.ForeignKey(
                        name: "fk_countries_regions_region_id",
                        column: x => x.region_id,
                        principalSchema: "public",
                        principalTable: "regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    country_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "public",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                schema: "public",
                table: "cities",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_id",
                schema: "public",
                table: "cities",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_name",
                schema: "public",
                table: "cities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_continentals_id",
                schema: "public",
                table: "continentals",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_continentals_name",
                schema: "public",
                table: "continentals",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_countries_id",
                schema: "public",
                table: "countries",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_countries_name",
                schema: "public",
                table: "countries",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_countries_region_id",
                schema: "public",
                table: "countries",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "ix_regions_continental_id",
                schema: "public",
                table: "regions",
                column: "continental_id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_id",
                schema: "public",
                table: "regions",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_regions_name",
                schema: "public",
                table: "regions",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "public");

            migrationBuilder.DropTable(
                name: "regions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "continentals",
                schema: "public");
        }
    }
}
