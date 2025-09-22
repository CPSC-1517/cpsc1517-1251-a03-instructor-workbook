using System.ComponentModel.DataAnnotations;

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
                //throw new NotImplementedException("TODO: implement LibraryId validation & assignment.");
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
                //throw new NotImplementedException("TODO: implement Name validation & assignment.");
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null", nameof(value));
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
                //throw new NotImplementedException("TODO: implement Address validation & assignment.");
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
            //throw new NotImplementedException("TODO: implement constructor body.");
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
            // 2) check for duplicate ISBN in Books (suggest: case-insensitive comparison)
            // 3) add to Books
            throw new NotImplementedException("TODO: implement AddBook.");
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
            // 2) locate matching book (same ISBN, case-insensitive)
            // 3) if not found -> throw; else remove
            throw new NotImplementedException("TODO: implement RemoveBook.");
        }

        // OPTIONAL: helper to compare ISBNs consistently in one place
        private static bool IsSameIsbn(string a, string b) =>
            string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
}
