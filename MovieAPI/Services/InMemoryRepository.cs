using MovieAPI.Entities;

namespace MovieAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;


        public InMemoryRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre() {Id = 1 , Name = "Action"},
                new Genre() {Id = 2 , Name = "Comedy"}
            };
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(1);
            return _genres;
        }

        public Genre GetGenreById(int Id)
        {
            return _genres.FirstOrDefault(x => x.Id == Id);
        }

        public void AddGenre(Genre genre)
        {
            genre.Id = _genres.Max(x => x.Id) + 1;
            _genres.Add(genre);
        }
    }
}
