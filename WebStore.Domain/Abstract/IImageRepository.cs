using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Abstract
{
    public interface IImageRepository
    {

        IQueryable<Image> GetImages();
        Image GetImageById(int? id);
        ObservableCollection<Image> ImagesInMemory();
        void AddNewImage(Image image);
        void DeleteImage(int id);
        void UpdateImage(Image image);
        void Dispose();

        void Save();
    }
}
