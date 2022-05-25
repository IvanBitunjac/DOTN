using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public string Summary { get; set; }
        public int ActorId { get; set; }
        public int GenreId { get; set; }

        [Ignore]
        public Actor Actor { get; set; }
        [Ignore]
        public Genre Genre { get; set; }
    }
}
