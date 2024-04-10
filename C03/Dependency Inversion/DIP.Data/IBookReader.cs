using System.Collections.Generic;

namespace DependencyInversionPrinciple.Data
{
    public interface IBookReader
    {
        IEnumerable<Book> Books { get; }
        Book Find(int bookId);
    }
}
