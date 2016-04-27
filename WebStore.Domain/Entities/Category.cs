using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
