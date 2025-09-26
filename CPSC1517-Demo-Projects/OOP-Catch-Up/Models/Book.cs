namespace OOP_Catch_Up.Models
{
    public class Book
    {
        // Define backing fields for properties
        private string _title = default!;
        private int _pages;

        // Define fully-implemented properties with backing field
        public string Title
        {
            get => _title;
            set
            {
                // Required validation
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(
                        nameof(Title), "Title is required.");
                _title = value.Trim();
            }
        }
        public int Pages
        {
            get => _pages;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(
                        nameof(Pages), "Pages must be > 0");
                _pages = value;
            }
        }

        // Greedy constructor
        public Book(string title, int pages)
        {
            Title = title;
            Pages = pages;
        }
    }
}
