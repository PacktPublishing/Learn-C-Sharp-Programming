using chapter_05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    class Rental
    {
        internal Book Book { get; set; }
        internal Movie Movie { get; set; }

        public Rental(Book book, Movie movie)
        {
            Book = book;
            Movie = movie;
        }
    }
    class RentalService : Rental, IMovie, IBook
    {
        public RentalService(Book book, Movie movie) : base(book, movie)
        {

        }
        public void GetMovieDetails()
        {
            Console.WriteLine("The movie {0} is rented for {1} days", Movie.MovieName, Movie.DaysRented);
        }
        int IMovie.CalculateRent()
        {
            return Movie.DaysRented * 5;
        }
        public void GetBookDetails()
        {
            Console.WriteLine("The book {0} is rented for {1} days", Book.BookName, Book.DaysRented);
        }
        int IBook.CalculateRent()
        {
            return Book.DaysRented * 10;
        }
    }
}
