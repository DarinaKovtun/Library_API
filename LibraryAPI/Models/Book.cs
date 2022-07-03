namespace LibraryAPI.Models
{
    public class Book
    {
        public long book_id { get; set; }

        public string name { get; set; }

        public string cover { get; set; }
        public string url { get; set; }

        public List<string> authors { get; set; }

        public string rating { get; set; }

        public string year { get; set; }

    }

    public class BookChoose : Book
    {
        public List<Book> books{ get; set; }
    }
}
