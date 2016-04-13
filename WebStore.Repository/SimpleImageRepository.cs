using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Abstract;
using WebStore.Domain.Entities;
using WebStore.DataLayer;
using System.Data.Entity;

namespace WebStore.Repository
{
    public class SimpleImageRepository : IImageRepository, IDisposable
    {
        private WebStoreDbContext ctx = new WebStoreDbContext();
        public void AddNewImage(Image image)
        {
            ctx.Images.Add(image);
        }

        public void DeleteImage(int id)
        {
            var image = ctx.Images.Find(id);

            ctx.Images.Remove(image);
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        public Image GetImageById(int? id)
        {
            return ctx.Images.Find(id);
        }

        public IQueryable<Image> GetImages()
        {
            return ctx.Images;
        }

        public ObservableCollection<Image> ImagesInMemory()
        {
            if (ctx.Images.Local.Count == 0)
            {
                GetImages();
            }
            return ctx.Images.Local;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }

        public void UpdateImage(Image image)
        {
            ctx.Entry(image).State = EntityState.Modified;
        }
    }
}
