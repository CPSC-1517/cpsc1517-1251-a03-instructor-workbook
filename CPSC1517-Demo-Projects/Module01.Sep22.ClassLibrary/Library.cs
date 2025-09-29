namespace Module01.Sep22.ClassLibrary
{
    /// <summary>
    /// A Library is a composite of Book items.
    /// </summary>
    public class Library
    {
        // Backing fields
        private string _libraryId = default!;
        private string _name = default!;
        private string? _address;

        // Collection: Books (private setter to enforce controlled changes)
        public List<Book> Books { get; private set; } = new();

        /// <summary>
        /// Required unique identifier for the library.
        /// </summary>
        public string LibraryId
        {
            get => _libraryId;
            private set
            {
                // TODO: validate required string (non-null, non-empty, non-blank) then trim
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("LibraryId cannot be null", nameof(value));
                }
                _libraryId = value.Trim();
            }
        }

        /// <summary>
        /// Required friendly name for the library.
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                // TODO: validate required string (non-null, non-empty, non-blank) then trim
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name),"Name cannot be null");
                }
                _name = value.Trim();
            }
        }

        /// <summary>
        /// Optional address. If provided, it cannot be empty/blank.
        /// </summary>
        public string? Address
        {
            get => _address;
            private set
            {
                // TODO: allow null; if not null, require non-empty/non-blank then trim
                // Hint: if (value is null) { _address = null; return; }
                
                if (value is null)
                {
                    _address = null;
                }
                else if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null", nameof(value));
                }
                else
                {
                    _address = value.Trim();
                }
                
            }
        }

        /// <summary>
        /// Read-only convenience: total number of books.
        /// </summary>
        public int TotalBooks => Books.Count;

        /// <summary>
        /// Composite constructor.
        /// </summary>
        /// <param name="libraryId">required</param>
        /// <param name="name">required</param>
        /// <param name="address">optional; if supplied, cannot be blank</param>
        /// <param name="books">optional initial collection; setter for Books is private so this is the only time a batch can be supplied</param>
        public Library(string libraryId, string name, string? address = null, List<Book>? books = null)
        {
            // TODO: assign LibraryId, Name, Address using property setters (so validation runs)
            LibraryId = libraryId;
            Name = name;
            Address = address;

            // Initialize Books
            // TODO: if 'books' is supplied:
            //  - ensure there are no duplicate ISBNs (case-insensitive recommended)
            //  - if duplicates exist, throw ArgumentException mentioning the offending ISBN
            //  - otherwise copy into Books (e.g., Books = new List<Book>(books))
            // If 'books' is null, keep the default empty list.
            // Initialize Books
            if (books != null)
            {
                for (int i = 0; i < books.Count; i++)
                {
                    for (int x = i + 1; x < books.Count; x++)
                    {
                        if (IsSameIsbn(books[i].ISBN, books[x].ISBN))
                        {
                            throw new ArgumentException($"Duplicate ISBN: {books[i].ISBN}.", nameof(books));
                        }
                    }
                }
                Books = new List<Book>(books);
            }


        }

        /// <summary>
        /// Adds a Book to the Books collection.
        /// Rules:
        ///  - book must not be null (throw ArgumentNullException)
        ///  - ISBN must be unique in the collection (throw ArgumentException including the ISBN)
        /// </summary>
        public void AddBook(Book book)
        {
            // TODO:
            // 1) null-check 'book'
            if (book is null)
            {
                throw new ArgumentNullException(nameof(book),"AddBook: book parameter cannot be null");
            }
            // 2) check for duplicate ISBN in Books (suggest: case-insensitive comparison)
            //bool isDuplicateISBN = false;
            //for (int index = 0; index < Books.Count && !isDuplicateISBN; index++)
            //{
            //    var currentBook = Books[index];
            //    if (currentBook.ISBN.ToUpper() == book.ISBN.ToUpper())
            //    //if (string.Equals(currentBook.ISBN, book.ISBN, StringComparison.OrdinalIgnoreCase))
            //    {
            //        isDuplicateISBN = true;
            //    }
            //}

            //bool isDuplicateISBN = FindByIsbn(book.ISBN) is null ? true : false;
            bool isDuplicateISBN = FindByIsbn(book.ISBN) is null;

            if (isDuplicateISBN)
            {
                throw new ArgumentException($"Error! Book ISBN {book.ISBN} is a duplicate.");
            }

            // 3) add to Books
            Books.Add(book);
        }

        /// <summary>
        /// Removes a Book matched by ISBN.
        /// Rules:
        ///  - isbn must be provided (non-null/non-blank) or throw ArgumentNullException
        ///  - if not found, throw ArgumentException including the provided isbn
        /// </summary>
        public void RemoveBook(string isbn)
        {
            // TODO:
            // 1) validate 'isbn' input (non-null/non-blank, then trim)
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException(nameof(isbn),"ISBN cannot be empty");
            }
            // 2) locate matching book (same ISBN, case-insensitive)
            var foundBook = FindByIsbn(isbn);
            if (foundBook == null) 
            {
                throw new ArgumentException($"Error! ISBN ${isbn} does not exists.");
            }

            // 3) if not found -> throw; else remove
            Books.Remove(foundBook);
        }

        public Book? FindByIsbn(string isbn)
        {
            Book? querySingleResult = null;
            for (int index = 0; index < Books.Count && querySingleResult is null; index++)
            {
                if (IsSameIsbn(Books[index].ISBN, isbn)) {
                    querySingleResult = Books[index];
                }
                
            }
            return querySingleResult;
        }

        // OPTIONAL: helper to compare ISBNs consistently in one place
        private static bool IsSameIsbn(string a, string b) =>
            string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
}
