using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models.repository
{
   public interface ICategorieRepository
    {
        IList<Categorie> GetAll();
        Categorie GetById(int id);
        void Add(Categorie c);
        Categorie Edit(Categorie newCategorie);
        Categorie Delete(int id);
    }
}
