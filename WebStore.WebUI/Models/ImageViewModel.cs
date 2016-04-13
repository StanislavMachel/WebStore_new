using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebStore.WebUI.Models
{
    public class ImageViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "AltText")]
        public string AltText { get; set; }

        [Display(Name = "Caption")]
        [DataType(DataType.Html)]
        public string Caption { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

    }
}
