using System;
using System.Linq;
using DIO.Movies.Model;
using DIO.Movies.Repositories;

namespace DIO.Movies
{
    public class MovieMenu
    {
        private const string MOVIE_NOT_FOUND_MESSAGE = "No movie was found.";

        private readonly MovieRepository _movieRepository;

        public MovieMenu(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void ShowMenu()
        {
            Console.WriteLine("How can I help you?");
            Console.WriteLine("1 - List movies");
            Console.WriteLine("2 - Insert a movie");
            Console.WriteLine("3 - Update a movie");
            Console.WriteLine("4 - Delete a movie");
            Console.WriteLine("c - Clear screen");
            Console.WriteLine("x - Exit");
            Console.WriteLine();
        }

        public bool ProcessOption(string option)
        {
            switch (option)
            {
                case ("1"):
                    ListMovies();
                    break;

                case ("2"):
                    InsertMovie();
                    break;

                case ("3"):
                    UpdateMovie();
                    break;

                case ("4"):
                    DeleteMovie();
                    break;

                case ("x"):
                    Console.WriteLine("Exiting...");
                    break;

                case ("c"):
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
            return option != "x";
        }

        private void ListMovies()
        {
            var movies = _movieRepository.List();
            if (!movies.Any())
            {
                Console.WriteLine(MOVIE_NOT_FOUND_MESSAGE);
                Console.WriteLine();
                return;
            }

            foreach (var m in movies)
            {
                Console.WriteLine(m.ToString());
            }
        }

        private void InsertMovie()
        {
            var movie = ReadMovieData();
            var id = _movieRepository.Insert(movie);
            Console.WriteLine($"The movie was successfully inserted. Id: {id}");
        }

        private void UpdateMovie()
        {
            var movies = _movieRepository.List();
            if (!movies.Any())
            {
                Console.WriteLine(MOVIE_NOT_FOUND_MESSAGE);
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Select the movie to update:");
            foreach (var m in movies)
            {
                Console.WriteLine($"{m.Id} - {m.Title}, {m.Year}");
            }
            var movieId = int.Parse(Console.ReadLine());
            var movie = _movieRepository.List(id: movieId).Single();
            Console.WriteLine("Movie to update:");
            Console.WriteLine(movie.ToString());
            Console.WriteLine();
            movie = ReadMovieData();
            movie.Id = movieId;
            _movieRepository.Update(movie);
            Console.WriteLine($"The movie with id {movieId} was successfully updated.");
        }

        private void DeleteMovie()
        {
            var movies = _movieRepository.List();
            if (!movies.Any())
            {
                Console.WriteLine(MOVIE_NOT_FOUND_MESSAGE);
                Console.WriteLine();
                return;
            }

            foreach (var m in movies)
            {
                Console.WriteLine($"{m.Id} - {m.Title}, {m.Year}");
            }
            var movieId = int.Parse(Console.ReadLine());
            _movieRepository.Delete(movieId);
            Console.WriteLine($"The movie with id {movieId} was successfully deleted.");
        }

        private Movie ReadMovieData()
        {
            var movie = new Movie();

            Console.WriteLine("Insert the movie title:");
            movie.Title = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Description:");
            movie.Description = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Year:");
            movie.Year = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Select the genre:");
            foreach (var enumValue in Enum.GetValues<Genre>())
            {
                Console.WriteLine($"{(int)enumValue + 1} - {Enum.GetName(enumValue)}");
            }
            var genre = int.Parse(Console.ReadLine()) - 1;
            movie.Genre = Enum.Parse<Genre>(genre.ToString());
            Console.WriteLine();

            return movie;
        }
    }
}