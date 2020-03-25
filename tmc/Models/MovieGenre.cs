using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
