using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStore.Domain.Abstract;
using WebStore.Domain.Entities;

namespace WebStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository productRepository;
        ICategoryRepository categoryRepository;
        public ProductController(IProductRepository productRepositoryParam, ICategoryRepository categoryRepositoryParam)
        {
            productRepository = productRepositoryParam;
            categoryRepository = categoryRepositoryParam;
        }
        // GET: Product
        public ActionResult Index()
        {
            var products = productRepository.GetProducts();
            ViewData["Categories"] = categoryRepository.GetGategories();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {

            ViewData["Categories"] = categoryRepository.GetGategories().ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Description,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.AddNewProduct(product);
                productRepository.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productRepository.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewData["Categories"] = categoryRepository.GetGategories().ToList();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Description,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(product);
                productRepository.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
