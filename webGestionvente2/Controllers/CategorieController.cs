using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webGestionvente2.Models;
using webGestionvente2.Models.repository;

namespace webGestionvente2.Controllers
{
    public class CategorieController : Controller
    {
        readonly ICategorieRepository categorierepository;
        public CategorieController(ICategorieRepository categorierepository)
        {
            this.categorierepository = categorierepository;
        }
        public IActionResult Index()
        {
            return View(categorierepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie c)
        {
            try
            {
                categorierepository.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie c)
        {
            try
            {
                categorierepository.Edit(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var categorie = categorierepository.GetById(id);
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Categorie ca = categorierepository.GetById(id);
                categorierepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
