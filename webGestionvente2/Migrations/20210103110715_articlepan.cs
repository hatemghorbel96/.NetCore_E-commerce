using Microsoft.EntityFrameworkCore.Migrations;

namespace webGestionvente2.Migrations
{
    public partial class articlepan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PanierArticles",
                columns: table => new
                {
                    PanierArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    PanierId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanierArticles", x => x.PanierArticleId);
                    table.ForeignKey(
                        name: "FK_PanierArticles_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanierArticles_ArticleID",
                table: "PanierArticles",
                column: "ArticleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PanierArticles");
        }
    }
}
