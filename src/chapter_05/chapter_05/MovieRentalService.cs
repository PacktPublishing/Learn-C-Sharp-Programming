using chapter_05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    public class Movie
    {
        internal string MovieName { get; set; }
        internal int DaysRented { get; set; }

        public Movie(string movieName, int daysRented)
        {
            MovieName = movieName;
            DaysRented = daysRented;
        }
    }
    class MovieRentalService : Movie, IMovie
    {
        public MovieRentalService(string movieName, int daysRented) : base(movieName, daysRented)
        {
        }

        public void GetMovieDetails()
        {
            Console.WriteLine("The movie {0} is rented for {1} days", MovieName, DaysRented);
        }

        public int CalculateRent()
        {
            return DaysRented * 5;
        }
    }
}
