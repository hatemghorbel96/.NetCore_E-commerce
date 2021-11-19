using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;
using webGestionvente2.Models.repository;
using webGestionvente2.viewmodele;

namespace webGestionvente2.Controllers
{
    public class PanierController : Controller
    {

        private readonly IArticleRepository _articleRepository;

        private readonly Panier _panier;

        public PanierController(IArticleRepository articleRepository, Panier panier)
        {
            _articleRepository = articleRepository;
            _panier = panier;
        }

        [Authorize]
        public ViewResult Index()
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


        [Authorize]
        public RedirectToActionResult AddToPanier(int id)
        {
            var selectArticle = _articleRepository.GetById(id);
            if (selectArticle != null)
            {
                _panier.AddPanier(selectArticle, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult DeleteFromPanier(int id)
        {
            var selectArticle = _articleRepository.GetById(id);
            if (selectArticle != null)
            {
                _panier.DeleteFromPanier(selectArticle);
            }
            return RedirectToAction("Index");
        }
    }
}


