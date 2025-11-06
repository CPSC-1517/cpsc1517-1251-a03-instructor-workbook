using BookBlazorApp.Models;

namespace BookBlazorApp.ViewModels
{
    public sealed class BookFormModel
    {
        public string? Title { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public BookGenre Genre { get; set; } = BookGenre.Fantasy;
        public bool InStock { get; set; }

        public static Book ToDomainModel(BookFormModel form)
        {
            return new Book(
                form.Title!,
                form.Pages,
                form.PublishDate,
                form.Genre,
                form.InStock);
        }
    }
}
