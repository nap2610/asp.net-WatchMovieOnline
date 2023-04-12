using MovieApp.Models;

namespace MovieApp.Service
{
    public interface IMovieService
    {
        public Task<List<Result>> GetTrending();
        public Task<List<Result>> GetUpcoming();
        public Task<List<Result>> GetPopular();
        public Task<List<Result>> GetTopRated();
        public Task<List<Genre>> GetGenre();
        public Task<Detail> GetDetail(int id);
        public Task<List<Result>> GetSimilarMovie(int id);
        public Task<List<Result>> GetGenreMovie(int id);
        public Task<List<Result>> GetSearchMovie(string key);
    }
}
