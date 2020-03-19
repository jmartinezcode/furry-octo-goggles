using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmc.Contracts;
using tmc.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace tmc.Services
{
    public class MovieService : IMovieServices
    {
        public MovieService()
        {

        }
        public async Task<Movie> GetPopularMovie()
        {
            return null;
        }
        public async Task<Movie> GetTopRatedMovie()
        {
            return null;
        }
        public async Task<Movie> GetNowPlayingMovie()
        {
            return null;
        }
        public async Task<Movie> GetUpcomingMovie()
        {
            return null;
        }

    }
}
