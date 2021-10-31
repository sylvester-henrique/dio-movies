using System;
using DIO.Movies.Repositories;

namespace DIO.Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            var movieRepository = new MovieRepository();
            var movieMenu = new MovieMenu(movieRepository);
            
            Console.WriteLine("Welcome to DIO Movies!");
            Console.WriteLine();

            var exit = false;
            do
            {
                movieMenu.ShowMenu();
                var option = Console.ReadLine().ToLower();
                Console.WriteLine();
                exit = !movieMenu.ProcessOption(option);

            } while (!exit);
        }
    }
}
