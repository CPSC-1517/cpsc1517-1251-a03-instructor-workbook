namespace WestWindBlazorApp.Models
{
    public sealed record TopAlbumsModel(
        string album,
        string artistName,
        string relaseDate,
        string genres,
        string descriptors,
        double averageRating,
        string numberRating,
        int numberViews)
    {
        /*
         *  "album": "Brother of the Son",
        "artistName": "Don Francisco",
        "releaseDate": "1976-01-01",
        "genres": "Contemporary Christian, Folk",
        "descriptors": "narrative, acoustic, spiritual, heartfelt, storytelling, male vocals",
        "averageRating": 4.5,
        "numberRatings": "12,345",
        "numberReviews": 234
        */
    }
}
