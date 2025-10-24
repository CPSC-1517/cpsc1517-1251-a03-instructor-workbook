using BookBlazorApp.Models;

namespace BookBlazorApp.ViewModels
{
    public sealed class BookEntryForm
    {
        public string? Title { get; set; }
        public int Pages { get; set; }
        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public BookGenre Genre { get; set; } = BookGenre.Fantasy;
        public bool InStock { get; set; }

        public static BookNoDataAnnotations ToDomainModel(BookEntryForm bookForm)
        {
            return new BookNoDataAnnotations(
                bookForm.Title!,
                bookForm.Pages,
                bookForm.PublishDate,
                bookForm.Genre,
                bookForm.InStock);
        }
    }
}
