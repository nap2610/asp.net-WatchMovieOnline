using MovieApp.Models;
using Newtonsoft.Json;
using System.Security.Policy;

namespace MovieApp.Service
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;
        private const string url = "http://localhost:5213/api/MoviesAPI/";

        public MovieService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Result>> GetTrending()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}trending"),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetUpcoming()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}upcoming"),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetPopular()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}popular"),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetTopRated()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}toprated"),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Genre>> GetGenre()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}genre"),
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Genre> result = JsonConvert.DeserializeObject<List<Genre>>(body);
                return result;
            }
        }

        public async Task<Detail> GetDetail(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}detail/{id}"),
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Detail result = JsonConvert.DeserializeObject<Detail>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetSimilarMovie(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}similar/{id}"),
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetGenreMovie(int id)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}genre-movie/{id}"),
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }

        public async Task<List<Result>> GetSearchMovie(string key)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{url}movielist/{key}"),
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                List<Result> result = JsonConvert.DeserializeObject<List<Result>>(body);
                return result;
            }
        }
    }//end class
}
