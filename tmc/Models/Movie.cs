using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tmc.Models
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        [NotMapped]
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public Genre[] genres { get; set; }
        public string homepage { get; set; }
        [Key]
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public Production_Companies[] production_companies { get; set; }
        public Production_Countries[] production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public Spoken_Languages[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Genre
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Production_Companies
    {
        [Key]
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class Production_Countries
    {
        [Key]
        public int id { get; set; }
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spoken_Languages
    {
        [Key]
        public int id { get; set; }
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }
    public class PopularMovie
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Movie[] results { get; set; }
    }
    public class TopRatedMovie
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Movie[] results { get; set; }
    }
    public class NowPlayingMovie
    {
        public Movie[] results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public Dates dates { get; set; }
        public int total_pages { get; set; }
    }
    public class UpcomingMovie
    {
        public Movie[] results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public Dates dates { get; set; }
        public int total_pages { get; set; }
    }
    public class SearchMovie
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Movie[] results { get; set; }
    }

    public class Dates
    {
        [Key]
        public int id { get; set; }
        public string maximum { get; set; }
        public string minimum { get; set; }
    }    
}
