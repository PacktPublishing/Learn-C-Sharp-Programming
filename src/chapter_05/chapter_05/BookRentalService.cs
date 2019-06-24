using chapter_05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    class Book
    {
        internal string BookName { get; set; }
        internal int DaysRented { get; set; }

        public Book(string bookName, int daysRented)
        {
            BookName = bookName;
            DaysRented = daysRented;
        }
    }
    class BookRentalService : Book, IBook
    {
        public BookRentalService(string bookName, int daysRented) : base(bookName, daysRented)
        {

        }
        public int CalculateRent()
        {
            return DaysRented * 10;
        }

        public void GetBookDetails()
        {
            Console.WriteLine("The book {0} is rented for {1} days", BookName, DaysRented);
        }
    }
}
