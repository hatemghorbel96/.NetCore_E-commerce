using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using webGestionvente2.Models;
using webGestionvente2.Models.repository;
using webGestionvente2.viewmodele;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace webGestionvente2.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategorieRepository _categorieRepository;
        private readonly IWebHostEnvironment hostEnvirement;

        public ArticleController(IArticleRepository articleRepository, IWebHostEnvironment hostEnvirement, ICategorieRepository categorieRepository)
        {
            this.hostEnvirement = hostEnvirement;
            _articleRepository = articleRepository;
            _categorieRepository = categorieRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _articleRepository.GetAll();
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var article = _articleRepository.GetById(id);
            return View(article);
        }

        public ActionResult Create()
        {
            ViewBag.categorieId = new SelectList(_categorieRepository.GetAll(), "CategorieId", "categorieName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewmodel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    String uploadFolder = Path.Combine(hostEnvirement.WebRootPath, "img");
                    uniqueFileName = Guid.NewGuid().ToString() + "-" + model.Photo.FileName;

                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Article newArticle = new Article
                {
                    nomArticle = model.nomArticle,
                    description = model.description,
                    prix = model.prix,
                    instock = model.instock,
                    categorieId = model.categorieId,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    imagepath = uniqueFileName
                };

                _articleRepository.Add(newArticle);
                return RedirectToAction("details", new { id = newArticle.ArticleID });



            }
                return View();
        }

        public ActionResult Edit(int id)
        {
            // var employee = _employeeRepository.FindByID(id);
            // return View(employee);
            ViewBag.categorieId = new SelectList(_categorieRepository.GetAll(), "CategorieId", "categorieName");
            Article article = _articleRepository.GetById(id);
            ArticleEditViewmodel articleEditViewmodel = new ArticleEditViewmodel
            {
                ArticleID = article.ArticleID,
                nomArticle = article.nomArticle,
                description = article.description,
                prix = (int)article.prix,
                instock = article.instock,
                categorieId = article.categorieId,
                ExistingPhotoPath = article.imagepath
                
            };
            return View(articleEditViewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleEditViewmodel model)
        {
           
            if (ModelState.IsValid)
            {
               
                Article article = _articleRepository.GetById(model.ArticleID);
                // Update the employee object with the data in the model object
                article.nomArticle = model.nomArticle;
                article.description = model.description;
                article.prix = model.prix;
                article.instock = model.instock;
                article.categorieId = model.categorieId;


                if (model.Photo != null)
                {
                    
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostEnvirement.WebRootPath,
                            "img", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    
                    article.imagepath = ProcessUploadedFile(model);
                }

                
                Article updatedArticle = _articleRepository.Edit(article);
                if (updatedArticle != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        [NonAction]
        private string ProcessUploadedFile(ArticleEditViewmodel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostEnvirement.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

        public ActionResult Delete(int id)
        {
            var article = _articleRepository.GetById(id);
            return View(article);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Article ar = _articleRepository.GetById(id);
                _articleRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult search(string term ,int? CategorieId)
        {
            var result = _articleRepository.GetAll();
            if (!string.IsNullOrEmpty(term))
                result = _articleRepository.Search(term);
            else
            if (CategorieId != null)
                result = _articleRepository.GetArticlesByCategorieID(CategorieId);
            ViewBag.categorieId = new SelectList(_categorieRepository.GetAll(), "CategorieId", "categorieName");
            return View("Index", result);
        }
    }
}
