using MovieAPI.Models;

namespace MovieApp.Models
{
    public class Root
    {
        public int page { get; set; }
        public List<Result>? results { get; set; }
        public List<Genre> genres { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

    }
}
