using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;

namespace webGestionvente2.viewmodele
{
    public class CommandeViewModel
    {
        public Commande Commande { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }


       

        public string Ville { get; set; }

        public int Numtel { get; set; }

        public DateTime Datecommande { get; set; }
    }
}
