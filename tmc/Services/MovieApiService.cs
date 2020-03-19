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
        string base_url = "https://api.themoviedb.org/3/movie/";
        string end_url = "&language=en-US&page=1";
        public MovieService()
        {
            
        }
        public async Task<Movie> GetPopularMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "popular?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            }
            return null;
        }
        public async Task<Movie> GetTopRatedMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "top_rated?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            }
            return null;
        }
        public async Task<Movie> GetNowPlayingMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "now_playing?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            }
            return null;
        }
        public async Task<Movie> GetUpcomingMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "upcoming?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Movie>(json);
            }
            return null;
        }
    }
}
