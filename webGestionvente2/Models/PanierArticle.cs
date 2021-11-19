using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class PanierArticle
    {
        public int PanierArticleId { get; set; }
        
        public int Montant { get; set; }
        public string PanierId { get; set; }

        public  Article Article { get; set; }
    }
}
