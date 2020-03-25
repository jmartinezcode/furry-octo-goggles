using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class MovieWatchlist
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("WatchlistId")]
        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
