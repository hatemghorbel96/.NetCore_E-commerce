using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models.repository
{
    public class CategorieRepository : ICategorieRepository
    {
        readonly AppDbContext context;

        public CategorieRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Categorie c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }

        public void Delete(Categorie c)
        {
           
        }

        public Categorie Delete(int id)
        {
            Categorie c1 = context.Categories.Find(id);
            if (c1 != null)
            {
                context.Categories.Remove(c1);
                context.SaveChanges();
            }
            return c1;
        }

        public IList<Categorie> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categorie GetById(int id)
        {
            return context.Categories.Find(id);
        }

        Categorie ICategorieRepository.Edit(Categorie newCategorie)
        {
            var categorie = context.Categories.Attach(newCategorie);
            categorie.State = EntityState.Modified;
            context.SaveChanges();
            return newCategorie;
        }
    }
}
