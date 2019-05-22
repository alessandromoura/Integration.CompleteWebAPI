using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.CompleteWebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Federations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Federation = table.Column<string>(maxLength: 250, nullable: false),
                    Acronym = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoundationDate = table.Column<DateTime>(nullable: false),
                    Mascot = table.Column<byte[]>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Championships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Championship = table.Column<string>(maxLength: 250, nullable: false),
                    Trophy = table.Column<byte[]>(nullable: true),
                    FederationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championships_Federations_FederationId",
                        column: x => x.FederationId,
                        principalTable: "Federations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Conquered = table.Column<DateTime>(nullable: false),
                    ChampionshipId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_Championships_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Titles_Titles_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Federations",
                columns: new[] { "Id", "Acronym", "Federation" },
                values: new object[,]
                {
                    { new Guid("7b1e286e-6faa-416a-8867-504dec147c84"), "FPF", "Federacao Paulista de Futebol" },
                    { new Guid("d597bc12-e5d6-4a68-93df-efa52e44abb6"), "CBF", "Confederacao Brasileira de Futebol" },
                    { new Guid("601171de-77ab-480d-a99d-054449e07fcf"), "FIFA", "Federation Internationale de Football Association" },
                    { new Guid("c9496af1-ac10-4e9f-8e7a-e92a49a2a337"), "CONMEBOL", "Confederacion Sudamericana de Futbol" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "FoundationDate", "Logo", "Mascot", "Name" },
                values: new object[] { new Guid("0ddde795-1460-43c0-a246-ae8168106f3f"), new DateTime(1910, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Sport Club Corinthians Paulista" });

            migrationBuilder.InsertData(
                table: "Championships",
                columns: new[] { "Id", "Championship", "FederationId", "Trophy" },
                values: new object[,]
                {
                    { new Guid("0d5891d9-9997-4e87-8316-33cf9c55b154"), "Campeonato Paulista de Futebol", new Guid("7b1e286e-6faa-416a-8867-504dec147c84"), null },
                    { new Guid("581c69cb-f267-467c-8add-dde491fcfeb7"), "Brasileirao", new Guid("d597bc12-e5d6-4a68-93df-efa52e44abb6"), null },
                    { new Guid("8089fec4-5072-44ef-a3c6-560822d09db1"), "Mundial de Clubes", new Guid("601171de-77ab-480d-a99d-054449e07fcf"), null },
                    { new Guid("ed31e62d-be30-4588-8eeb-a072bdf37c25"), "Libertadores da America", new Guid("c9496af1-ac10-4e9f-8e7a-e92a49a2a337"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championships_FederationId",
                table: "Championships",
                column: "FederationId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_ChampionshipId",
                table: "Titles",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_TeamId",
                table: "Titles",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Championships");

            migrationBuilder.DropTable(
                name: "Federations");
        }
    }
}
