using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStore.Domain.Abstract;
using WebStore.Domain.Entities;
using WebStore.WebUI.Models;

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
            var categories = categoryRepository.GetGategories();
            List<ProductViewModel> productViewModels =  new List<ProductViewModel>();
            foreach (var product in products)
            {
                var category = categories.First(x => x.CategoryID == product.CategoryID).Name;

                ProductViewModel productViewModel = new ProductViewModel()
                {
                    ProductID = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    Category = category
                };

                productViewModels.Add(productViewModel);
            }
            return View(productViewModels);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = productRepository.GetProductById(id);
            var category = categoryRepository.GetGategories().First(x => x.CategoryID == product.CategoryID).Name;
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewData["ID"] = product.ProductID;
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                Category = category
            };

            return View(productViewModel);
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
        public ActionResult Create(/*[Bind(Include = "ProductID,Name,Description,Category")]*/ ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = productViewModel.Name,
                    Description = productViewModel.Description,
                    CategoryID = categoryRepository.GetGategories().First(x => x.Name == productViewModel.Category).CategoryID
                };
                productRepository.AddNewProduct(product);
                productRepository.Save();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
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
