using System;

namespace DIO.Movies.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}{Environment.NewLine}" +
                $"Description: {Description}{Environment.NewLine}" +
                $"Genre: {Genre}{Environment.NewLine}" +
                $"Year: {Year}{Environment.NewLine}";
        }
    }
}