using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models.repository
{
  public interface IArticleRepository
    {
        IList<Article> GetAll();
        Article GetById(int id);
        void Add(Article a);
        Article Edit(Article newArticle);
       
        Article Delete(int id);
        IList<Article> Search(String term);

        IList<Article> GetArticlesByCategorieID(int? CategorieId);
    }
}
