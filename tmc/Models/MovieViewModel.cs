using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public Watchlist Watchlist { get; set; }
        public PopularMovie PopularMovie { get; set; }
        public TopRatedMovie TopRatedMovie { get; set; }
        public NowPlayingMovie NowPlayingMovie { get; set; }
        public UpcomingMovie UpcomingMovie { get; set; }
    }
}
