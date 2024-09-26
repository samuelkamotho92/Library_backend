namespace Library.Model
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty ;

        public DateTime publishedDate { get; set; }
    }
}
