using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webGestionvente2.Models
{
    public class Commande
    {
        [BindNever]
        public int CommandeId { get; set; }
        public ICollection<CommandeDetail> Lignecommande { get; set; }
       
        public string Nom { get; set; }
       
        public string Prenom { get; set; }
      
        public string Adresse { get; set; }
       
       
        public int Codepostal { get; set; }
        
        public string Ville { get; set; }
       
        public string Pays { get; set; }
       
        public string Email { get; set; }
      
        public int Numtel { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public decimal Commandetotal { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime Datecommande { get; set; }
        
    }
}
