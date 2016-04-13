using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.WebUI.Models;
using WebStore.Domain.Abstract;
using WebStore.Domain.Entities;
using System.IO;

namespace WebStore.WebUI.Controllers
{
    public class ImageController : Controller
    {
        private IImageRepository repository;
        public ImageController(IImageRepository repositoryParam)
        {
            repository = repositoryParam;
        }
        // GET: Image
        public ActionResult Create()
        {
            return View(new ImageViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel model)
        {
            string[] validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "Please select image for uploading.");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                Image image = new Image
                {
                    Title = model.Title,
                    AltText = model.AltText,
                    Caption = model.Caption
                };

                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = "~/uploads";
                    var fileName = System.IO.Path.GetFileName(model.ImageUpload.FileName);
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), fileName);
                    var imageUrl = Path.Combine(uploadDir, fileName);
                    if (System.IO.File.Exists(imagePath))
                        ;
                    else
                        ;

                    model.ImageUpload.SaveAs(imagePath);
                    image.ImageUrl = imageUrl;
                }

                repository.AddNewImage(image);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}