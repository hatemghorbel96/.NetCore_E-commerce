using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;

namespace webGestionvente2.Models.repository
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly AppDbContext context;
        private readonly Panier _panier;

        public CommandeRepository(AppDbContext context, Panier panier)
        {
            this.context = context;
            _panier = panier;
        }
        public void ajouterCommande(Commande commande)
        {
           
            commande.Datecommande = DateTime.Now;
            commande.Commandetotal = _panier.SommePanier();
            context.Commandes.Add(commande);
            context.SaveChanges();
            var panierarticles = _panier.PanierArticles;

            foreach (var panierArticle in panierarticles)
            {
                var commandeDetail = new CommandeDetail()
                {
                    Montant = panierArticle.Montant,
                    ArticleID = panierArticle.Article.ArticleID,
                    CommandeId = commande.CommandeId,
                    Prix = panierArticle.Article.prix,
                    
                   
            };
                context.CommandeDetails.Add(commandeDetail);
                context.SaveChanges();


            }
            
        }

        public void Delete(Commande c)
        {
            Commande c1 = context.Commandes.Find(c.CommandeId);
            if (c1 != null)
            {
                context.Commandes.Remove(c1);
                context.SaveChanges();
            }
        }

        public IList<Commande> GetAllCom()
        {
            return context.Commandes.ToList();
        }

        public Commande GetById(int id)
        {
            return context.Commandes.Find(id);
        } 

        IList<CommandeDetail> ICommandeRepository.GetAll()
        {
            return context.CommandeDetails.ToList();
        }
    }
}
