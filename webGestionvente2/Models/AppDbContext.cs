
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<PanierArticle> PanierArticles { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<CommandeDetail> CommandeDetails { get; set; }


    }
}
