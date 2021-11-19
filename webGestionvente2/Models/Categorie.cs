using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string categorieName { get; set; }
        public string description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
