using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models.repository
{
   public interface ICommandeRepository
    {
        void ajouterCommande(Commande commande);

        IList<CommandeDetail> GetAll();

        IList<Commande> GetAllCom();

        void Delete(Commande c);

        Commande GetById(int id);
    }
}
