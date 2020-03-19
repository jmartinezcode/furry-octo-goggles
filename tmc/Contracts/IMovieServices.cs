using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmc.Models;

namespace tmc.Contracts
{
    public interface IMovieServices
    {
        Task<PopularMovie> GetPopularMovie();
        Task<TopRatedMovie> GetTopRatedMovie();
        Task<NowPlayingMovie> GetNowPlayingMovie();
        Task<UpcomingMovie> GetUpcomingMovie();
    }
}
