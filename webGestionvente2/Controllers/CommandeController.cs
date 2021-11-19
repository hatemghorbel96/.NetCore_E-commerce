using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;
using webGestionvente2.Models.repository;
using webGestionvente2.viewmodele;

namespace webGestionvente2.Controllers
{
    public class CommandeController : Controller
    {
        private readonly ICommandeRepository _commandeRepository;
        private readonly Panier _Panier;
        private readonly IArticleRepository _articleRepository;

        public CommandeController(ICommandeRepository  commandeRepository, Panier panier, IArticleRepository articleRepository)
        {
            _commandeRepository = commandeRepository;
            _Panier = panier;
            _articleRepository = articleRepository;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Commande commande)
        {
            var items = _Panier.GetPanierArticles();
            _Panier.PanierArticles = items;
            if (_Panier.PanierArticles.Count == 0)
            {
                ModelState.AddModelError("", "Il n'y a plus d'articles dans votre panier, ajouter des articles");
            }

            if (ModelState.IsValid)
            {
                _commandeRepository.ajouterCommande(commande);
                
                return RedirectToAction("CheckoutComplete");
            }

            return View(commande);
        }

        public IActionResult CheckoutComplete(int id)
        {
            var PanierTotal = _Panier.SommePanier();
            ViewBag.CheckoutCompleteMessage = "votre commande est prête";
            ViewBag.test = _Panier.SommePanier();
            DateTime today = DateTime.Now;
            DateTime today2 = DateTime.Now;
            DateTime answer = today2.AddDays(3);
            // var com = new CommandeDetail();
            //  var n = com.Article.nomArticle;
            // ViewBag.comid = n;
            ViewBag.comid1 = today.Date.ToString("dd/MM/yyyy");
            ViewBag.comid = answer.Date.ToString("dd/MM/yyyy");
            return View();
        }

        public IActionResult valid()
        {
            
            return RedirectToAction("ValidCom");
        }

        public IActionResult viderpanier()
        {
            _Panier.Deletepanier();
            return RedirectToAction("ValidCom");
        }

        public IActionResult ValidCom()
        {
            ViewBag.test = _Panier.SommePanier();
            DateTime today = DateTime.Now;
           
            ViewBag.comid1 = today;
           
            return View();
        }
        public IActionResult Listcommande()
        {
         /*   ViewBag.CommandeId = new(_commandeRepository.GetAllCom(), "CommandeId", "Nom");*/
            return View(_commandeRepository.GetAll());
        }

        public IActionResult ListComtest()
        {
            /*   ViewBag.CommandeId = new(_commandeRepository.GetAllCom(), "CommandeId", "Nom");*/
            return View(_commandeRepository.GetAllCom());
        }

        public RedirectToActionResult DeleteCom(int id)
        {
            var comse = _commandeRepository.GetById(id);
            if (comse != null)
            {
                _commandeRepository.Delete(comse);
            }
            return RedirectToAction("ListComtest");
        }
    }
}
