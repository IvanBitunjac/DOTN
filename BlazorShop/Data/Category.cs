using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Data
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Naziv kategorije je obavezan")]
        [Display(Name="Naziv kategorije")]
        public string Name { get; set; }

    }
}
