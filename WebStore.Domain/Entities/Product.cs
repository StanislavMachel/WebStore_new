using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Product
    {
        //public Product()
        //{

            //Images = new List<Image>();
        //}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        
        //public virtual ICollection<Image> Images { get; set; }

    }
}
