using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Naziv proizvoda je obavezan")]
        [Display(Name = "Naziv proizvoda")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cijena je obavezna")]
        [Range(0, 500)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boja je obavezna")]
        public string Color { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
