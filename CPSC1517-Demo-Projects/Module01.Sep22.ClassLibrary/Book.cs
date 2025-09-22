namespace Module01.Sep22.ClassLibrary
{
    /// <summary>
    /// Represents a single book record with validated state and controlled mutation.
    /// </summary>
    public class Book
    {
        // Backing fields
        private string _isbn = default!;
        private string _title = default!;
        private string _author = default!;
        private int _pages;

        // Constants
        private const int MIN_PAGES = 10;

        // Public read-only properties (private setters force use of behaviors)
        public string ISBN
        {
            get => _isbn;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(ISBN), "ISBN is required (non-empty, non-blank).");
                }

                _isbn = value.Trim();
            }
        }

        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Title), "Title is required (non-empty, non-blank).");
                }

                _title = value.Trim();
            }
        }

        public string Author
        {
            get => _author;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Author), "Author is required (non-empty, non-blank).");
                }

                _author = value.Trim();
            }
        }

        public int Pages
        {
            get => _pages;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Pages must be a positive non-zero number. Received: {value}.", nameof(Pages));
                }

                if (value < MIN_PAGES)
                {
                    throw new ArgumentException($"Pages must be at least {MIN_PAGES}. Received: {value}.", nameof(Pages));
                }

                _pages = value;
            }
        }

        // Constructor
        public Book(string isbn, string title, string author, int pages)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Pages = pages;
        }

        // Behaviors (controlled mutation with validation)
        public void ChangeTitle(string newTitle) => Title = newTitle;

        public void ChangePages(int newPages) => Pages = newPages;

        public override string ToString() => $"{ISBN},{Title},{Author},{Pages}";
    }
}
