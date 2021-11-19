using webGestionvente2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.viewmodele
{
    public class CreateViewmodel
    {
        public string nomArticle { get; set; }
        public string description { get; set; }
        public int prix { get; set; }
        public IFormFile Photo { get; set; }
        public Boolean instock { get; set; }
        public int categorieId { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}
