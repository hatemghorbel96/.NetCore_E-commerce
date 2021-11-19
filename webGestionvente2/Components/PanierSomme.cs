using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;
using webGestionvente2.viewmodele;

namespace webGestionvente2.Components
{
    public class PanierSomme : ViewComponent
    {
        private readonly Panier _panier;
        public PanierSomme(Panier panier)
        {
            _panier = panier;
        }

        public IViewComponentResult Invoke()
        {
            var items = _panier.GetPanierArticles();
            _panier.PanierArticles = items;

            var panierviewmodel = new Panierviewmodel
            {
                Panier = _panier,
                PanierTotal = _panier.SommePanier()
            };
            return View(panierviewmodel);
        }
    }
}
