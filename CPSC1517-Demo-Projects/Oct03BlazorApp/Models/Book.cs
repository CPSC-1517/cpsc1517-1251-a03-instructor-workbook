namespace Oct03BlazorApp.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Genre { get; set; } = "Fiction";
        public bool InStock { get; set; }
    }
}
