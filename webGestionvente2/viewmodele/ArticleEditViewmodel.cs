using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.viewmodele
{
    public class ArticleEditViewmodel : CreateViewmodel
    {
        public int ArticleID { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
