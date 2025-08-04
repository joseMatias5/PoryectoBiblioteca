namespace Domain.Entities;

public class Book : EntityBase
{
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public string? Description { get; set; } = null;
    public Category Category { get; set; }
    public int? PublicationYear { get; set; }
    public string? Author { get; set; }

    public List<Loan>? Loans { get; set; } = new List<Loan>();
    public Book()
    {
    }
    public Book(string title, string isbn, Category category, int publicationYear, string author, string? description)
    {
        Title = title;
        ISBN = isbn;
        Description = description;
        Category = category;
        PublicationYear = publicationYear;
        Author = author;
    }
}
