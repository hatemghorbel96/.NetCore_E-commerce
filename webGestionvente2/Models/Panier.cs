using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class Panier
    {
        private readonly AppDbContext _appDbContext;
        private Panier(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string PanierId { get; set; }
        public List<PanierArticle> PanierArticles { get; set; }

        internal static Panier GetPanier(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
             .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Panier(context) { PanierId = cartId };
        }

        public void AddPanier(Article article, int montant)
        {
            var panierArticle =
                    _appDbContext.PanierArticles.SingleOrDefault(
                        s => s.Article.ArticleID == article.ArticleID && s.PanierId == PanierId);

            if (panierArticle == null)
            {
                panierArticle = new PanierArticle
                {
                    PanierId = PanierId,
                    Article = article,
                    Montant = 1
                };

                _appDbContext.PanierArticles.Add(panierArticle);
            }
            else
            {
                panierArticle.Montant++;
            }
            _appDbContext.SaveChanges();
        }


        public int DeleteFromPanier(Article article)
        {
            var panierArticle =
                    _appDbContext.PanierArticles.SingleOrDefault(
                        s => s.Article.ArticleID == article.ArticleID && s.PanierId == PanierId);

            var localMontant = 0;

            if (panierArticle != null)
            {
                if (panierArticle.Montant > 1)
                {
                    panierArticle.Montant--;
                    localMontant = panierArticle.Montant;
                }
                else
                {
                    _appDbContext.PanierArticles.Remove(panierArticle);
                }
            }

            _appDbContext.SaveChanges();

            return localMontant;
        }

        public List<PanierArticle> GetPanierArticles()
        {
            return PanierArticles ??
                   (PanierArticles =_appDbContext.PanierArticles.Where(c => c.PanierId == PanierId).Include(s => s.Article).ToList());
        }

        public void Deletepanier()
        {
            var cartItems = _appDbContext.PanierArticles.Where(cart => cart.PanierId == PanierId);

            _appDbContext.PanierArticles.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal SommePanier()
        {
            var total = _appDbContext.PanierArticles.Where(c => c.PanierId == PanierId).Select(c => c.Article.prix * c.Montant).Sum();
            return total;
        }


    }



}
