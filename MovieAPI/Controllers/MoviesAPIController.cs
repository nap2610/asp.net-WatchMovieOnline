using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieApp.Models;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesAPIController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private const string api_key = "fded51c2600f922c2563a6177bdc78d0";

        public MoviesAPIController() {
            _httpClient = new HttpClient();
        }

        [HttpGet("trending")]
        public async Task<List<Result>> GetTrending() {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/trending/movie/week?api_key={api_key}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet("upcoming")]
        public async Task<List<Result>> GetUpComing()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/upcoming?api_key={api_key}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet("popular")]
        public async Task<List<Result>> GetPopular()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/popular?api_key={api_key}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet("toprated")]
        public async Task<List<Result>> GetTopRated()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/top_rated?api_key={api_key}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet("genre")]
        public async Task<List<Genre>> GetGenre()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/genre/movie/list?api_key={api_key}"),
            };
            List<Genre> m = new List<Genre>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.genres)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet]
        [Route("detail/{id}")]
        public async Task<Detail> GetDetail(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{id}?api_key={api_key}&append_to_response=videos,casts"),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Detail result = JsonConvert.DeserializeObject<Detail>(body);
                return result;
            }
        }

        [HttpGet("similar/{id}")]
        public async Task<List<Result>> GetSimilarMovie(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/movie/{id}/similar?api_key={api_key}&language=en-US"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }


        [HttpGet("genre-movie/{id}")]
        public async Task<List<Result>> GetGenreMovie(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/discover/movie?api_key={api_key}&language=en-US&sort_by=popularity.desc&with_genres={id}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }

        [HttpGet("movielist/{key}")]
        public async Task<List<Result>> GetSearchMovie(string key)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={api_key}&language=en-US&query={key}"),
            };
            List<Result> m = new List<Result>();
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Root result = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in result.results)
                {
                    m.Add(item);
                }
                return m;
            }
        }



    }
}
