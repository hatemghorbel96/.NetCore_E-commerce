using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string nomArticle { get; set; }
        public string description { get; set; }
        public decimal prix { get; set; }
        public string imagepath { get; set; }
        public Boolean instock { get; set; }
        public int categorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
