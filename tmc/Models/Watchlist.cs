using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class Watchlist
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProfileId")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        
    }
}
