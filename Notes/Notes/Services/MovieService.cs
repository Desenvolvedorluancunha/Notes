using Newtonsoft.Json;
using Notes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services
{
    public class MovieService
    {

        private HttpClient _client = new HttpClient();
        private List<Movie> _movies;
        private List<Search> _teste;


        public async Task<List<Movie>> LocalizarFilmesPorAtor(string filme)
        {
            try
            {
                if (string.IsNullOrEmpty(filme))
                {
                    return null;
                }
                else
                {
                    string url = string.Format($"https://www.omdbapi.com/?apikey=1a72b1e4&/&s={filme}");

                    var response = await _client.GetAsync(url);

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        _movies = new List<Movie>();
                    }
                    else
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        var movies = (Class1)JsonConvert.DeserializeObject(content, new Class1().GetType());

                        var xxx = movies.Search.Count();

                        _movies = new List<Movie>();
                        for (int i = 0; i < xxx; i++)
                        {
                            var movie = new Movie();

                            movie.TITLE = movies.Search[i].Title;
                            movie.RELEASE_YEAR = movies.Search[i].Year;
                            movie.SUMARY = movies.Search[i].Type;
                            movie.IMAGEMS_URL = movies.Search[i].Poster;

                            _movies.Add(movie);
                        }
                        
                        
                    }

                    return _movies;
                }
            }
            catch (Exception ex)
            {
                var xx = ex;
                return null;
            }
        }

    }
}
