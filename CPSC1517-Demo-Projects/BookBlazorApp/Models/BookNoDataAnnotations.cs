namespace BookBlazorApp.Models
{
    public class BookNoDataAnnotations
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public BookGenre Genre { get; set; } = BookGenre.Fantasy;
        public bool InStock { get; set; }

        public BookNoDataAnnotations() { }

        public BookNoDataAnnotations(string title, int pages, 
            DateOnly publishDate, BookGenre genre, bool inStock)
        {
            Title = title;
            Pages = pages;
            PublishDate = publishDate;
            Genre = genre;
            InStock = inStock;
        }

        public override string ToString()
        {
            return $"{Title},{Pages},{PublishDate},{Genre},{InStock}";
        }

        public static BookNoDataAnnotations Parse(string csvLine)
        {
            if (string.IsNullOrWhiteSpace(csvLine))
            {
                throw new ArgumentNullException(nameof(csvLine), "Parameter value cannot be blank.");
            }
            // Title (0), Pages (1), PublishDate (2), Genre (3), InStock (4)
            string[] fields = csvLine.Split(',');
            // Verify the line contains exactly 5 values separated by a comma
            if (fields.Length != 5)
            {
                throw new FormatException($"Parameter value {csvLine} is incorrect format.");
            }
            string title = fields[0];
            int pages = int.Parse(fields[1]);
            DateOnly publishDate = DateOnly.Parse(fields[2]);
            BookGenre genre = Enum.Parse<BookGenre>(fields[3]);
            bool inStock = bool.Parse(fields[4]);
            // Return an BookNoDataAnnotations instance with all the values
            return new BookNoDataAnnotations(title, pages, publishDate, genre, inStock);
        }
    }
}
