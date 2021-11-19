using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class CommandeDetail
    {
        public int CommandeDetailId { get; set; }  
        public int Montant { get; set; }
        public decimal Prix { get; set; }
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public int CommandeId { get; set; }
        public virtual Commande Commande { get; set; }
    }
}
