using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmc.Models;

namespace tmc.Contracts
{
    public interface IMovieServices
    {
        Task<Movie> GetPopularMovie();
        Task<Movie> GetTopRatedMovie();
        Task<Movie> GetNowPlayingMovie();
        Task<Movie> GetUpcomingMovie();
    }
}
