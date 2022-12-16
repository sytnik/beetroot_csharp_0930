namespace Lesson30;

public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<Book> Books { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string BookName { get; set; }
    public List<Author> Authors { get; set; }
}

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}