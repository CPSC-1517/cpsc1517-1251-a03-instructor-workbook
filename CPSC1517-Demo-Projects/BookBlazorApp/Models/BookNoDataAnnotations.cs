namespace BookBlazorApp.Models
{
    public class BookNoDataAnnotations
    {
        public string? Title { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Genre { get; set; } = "Fiction";
        public bool InStock { get; set; }

        public override string ToString()
        {
            return $"{Title},{Pages},{PublishDate},{Genre},{InStock}";
        }

        
    }
}
