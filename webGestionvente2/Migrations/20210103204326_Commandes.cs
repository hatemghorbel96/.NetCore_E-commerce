using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webGestionvente2.Migrations
{
    public partial class Commandes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codepostal = table.Column<int>(type: "int", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numtel = table.Column<int>(type: "int", nullable: false),
                    Commandetotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Datecommande = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.CommandeId);
                });

            migrationBuilder.CreateTable(
                name: "CommandeDetails",
                columns: table => new
                {
                    CommandeDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    CommandeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeDetails", x => x.CommandeDetailId);
                    table.ForeignKey(
                        name: "FK_CommandeDetails_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeDetails_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "CommandeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandeDetails_ArticleID",
                table: "CommandeDetails",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_CommandeDetails_CommandeId",
                table: "CommandeDetails",
                column: "CommandeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeDetails");

            migrationBuilder.DropTable(
                name: "Commandes");
        }
    }
}
