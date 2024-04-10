using DependencyInversionPrinciple.Data;
using System;

namespace DependencyInversionPrinciple.App
{
    public class BookPresenter
    {
        public void Display(Book book)
        {
            Console.WriteLine($"Book: {book.Title} ({book.Id})");
        }
    }
}
