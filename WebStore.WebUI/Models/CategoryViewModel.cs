using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.WebUI.Models
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
 