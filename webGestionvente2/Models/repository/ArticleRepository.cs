using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models.repository
{
    public class ArticleRepository : IArticleRepository
    {
        readonly AppDbContext context;
        
        public ArticleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Article a)
        {
            context.Articles.Add(a);
            context.SaveChanges();
        }

       

      

        public IList<Article> GetAll()
        {
            return context.Articles.OrderBy(x => x.nomArticle).Include(x => x.Categorie).ToList();
        }

        public Article GetById(int id)
        {
            return context.Articles.Where(x => x.ArticleID == id).Include(x => x.Categorie).SingleOrDefault();
        }

        Article IArticleRepository.Delete(int id)
        {
            Article a1 = context.Articles.Find(id);
            if (a1 != null)
            {
                context.Articles.Remove(a1);
                context.SaveChanges();
            }
            return a1;
        }

        Article IArticleRepository.Edit(Article newArticle)
        {
            var article = context.Articles.Attach(newArticle);
            article.State = EntityState.Modified;
            context.SaveChanges();
            return newArticle;
        }

      

        IList<Article> IArticleRepository.Search(string term)
        {
            return context.Articles.Where(a => a.nomArticle.Contains(term)).Include(std => std.Categorie).ToList();
        }

        public IList<Article> GetArticlesByCategorieID(int? schid)
        {
            return context.Articles.Where(s => s.categorieId.Equals(schid))
               .OrderBy(s => s.nomArticle)
               .Include(std => std.Categorie).ToList();

        }
    }
}
