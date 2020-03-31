using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class MovieRating
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProfileId")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int MovieId { get; set; }        
        public int Rating { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
