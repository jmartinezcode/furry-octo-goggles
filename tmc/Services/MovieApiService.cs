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
        public async Task<PopularMovie> GetPopularMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "popular?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PopularMovie>(json);
            }
            return null;
        }
        public async Task<TopRatedMovie> GetTopRatedMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "top_rated?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<TopRatedMovie>(json);
            }
            return null;
        }
        public async Task<NowPlayingMovie> GetNowPlayingMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "now_playing?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<NowPlayingMovie>(json);
            }
            return null;
        }
        public async Task<UpcomingMovie> GetUpcomingMovie()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(base_url + "upcoming?api_key=" + API_KEYS.TheMovieDbAPI + end_url);
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<UpcomingMovie>(json);
            }
            return null;
        }
    }
}
