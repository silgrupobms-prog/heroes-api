using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Heroes.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "heroes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    weight = table.Column<int>(type: "integer", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heroes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "power",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    superpower = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_power", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hero_power",
                columns: table => new
                {
                    heroe_id = table.Column<int>(type: "integer", nullable: false),
                    power_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hero_power", x => new { x.heroe_id, x.power_id });
                    table.ForeignKey(
                        name: "FK_hero_power_heroes_heroe_id",
                        column: x => x.heroe_id,
                        principalTable: "heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hero_power_power_power_id",
                        column: x => x.power_id,
                        principalTable: "power",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "power",
                columns: new[] { "id", "description", "superpower" },
                values: new object[,]
                {
                    { 1, "Capacidade de levantar objetos extremamente pesados.", "Super Força" },
                    { 2, "Capacidade de voar em altas velocidades.", "Voo" },
                    { 3, "Pode ficar invisível à vontade.", "Invisibilidade" },
                    { 4, "Capacidade de ler e comunicar-se com a mente.", "Telepatia" },
                    { 5, "Mover objetos com o poder da mente.", "Telecinese" },
                    { 6, "Capacidade de se mover em velocidades incríveis.", "Velocidade Sobrehumana" },
                    { 7, "Capacidade de curar ferimentos rapidamente.", "Regeneração" },
                    { 8, "Manipular e gerar fogo com as mãos.", "Controle do Fogo" },
                    { 9, "Manipular a água e criar formas com ela.", "Controle da Água" },
                    { 10, "Criar barreiras protetoras invisíveis.", "Campo de Força" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_hero_power_power_id",
                table: "hero_power",
                column: "power_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hero_power");

            migrationBuilder.DropTable(
                name: "heroes");

            migrationBuilder.DropTable(
                name: "power");
        }
    }
}
