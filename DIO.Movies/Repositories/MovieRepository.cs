using System.Collections.Generic;
using System.Linq;
using DIO.Movies.Model;

namespace DIO.Movies.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public int Insert(Movie item)
        {
            item.Id = _movies.Count;
            _movies.Add(item);
            return item.Id;
        }

        public IEnumerable<Movie> List(int? id = null)
        {
            return _movies
                .Where(m => id is null || m.Id == id.Value);
        }

        public void Update(Movie item)
        {
            _movies[item.Id] = item;
        }

        public void Delete(int id)
        {
            var movie = _movies.Single(m => m.Id == id);
            _movies.Remove(movie);
        }
    }
}