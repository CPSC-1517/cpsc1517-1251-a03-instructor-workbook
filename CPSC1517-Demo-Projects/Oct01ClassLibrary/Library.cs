using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct01ClassLibrary
{
    public class Library
    {
        private List<Book> _books = new();

        public List<Book> Books => _books;

        public void AddBook(Book book)
        {
            // Verify book is not null
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book),"Book cannot be null");
            }
            // Check for duplicate book Title and throw ArgumentException if duplicate
            _books.Add(book);
        }

        public void RemoveBook(string title)
        {
            Book? book = FindByTitle(title);
            if (book is null)
            {
                throw new ArgumentException($"Title {title} does not exists");
            }
            Books.Remove(book);
        }

        private Book? FindByTitle (string title)
        {
            Book? foundBook = null;
            for (int index = 0; index < _books.Count && foundBook is null; index++)
            {
                if (Books[index].Title == title)
                {
                    foundBook = _books[index];
                }
            }
            return foundBook;
        }
    }
}
