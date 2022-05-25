
using PublisherData;
using PublisherDomain;

// Ensures Database is existed, if not will create it.
using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

var _context = new PubContext();
SequenceOfSteps();

/// Program Start point method
void SequenceOfSteps()
{
    //GetAuthors();
    //AddIAuthor();
    //GetAuthors();

    //AddAuthorWithBooks();
    //GetAuthorWithBooks();

    QueryFilterByName("Julie");
}

void QueryFilterByName(string name)
{
    var authors = _context.Authors.Where(s => s.FirstName == name).ToList();

    foreach (var item in authors)
    {
        Console.WriteLine($"{item.FirstName} {item.LastName} {BooksAny(item.Id)}");
    }
}

string BooksAny(int id)
{
    string? msg = default;
    var books = _context.Books.Where(b => b.AuthorId == id).ToList();
    foreach (var item in books)
    {
        msg += $" {item.Title} {item.PublishDate} \t";
    }
    return msg;
}

void AddAuthorWithBooks()
{
    var author = new Author { FirstName = "Julie", LastName = "Larmen" };
    author.Books.Add(new Book { AuthorId = 2, Title = "Entity Framework 6 Basics", PublishDate = new DateTime(2019, 1, 12) });
    author.Books.Add(new Book { AuthorId = 2, Title = "Entity Framework 6 Advanced", PublishDate = new DateTime(2021, 3, 20) });

    _context.Authors.Add(author);
    _context.SaveChanges();
}

void GetAuthorWithBooks()
{

    var books = _context.Books.ToList();
    var author = _context.Authors.ToList();
    books.ForEach(x => Console.WriteLine($"{x.Author.FirstName} {x.Author.LastName}: {x.Title} --- {x.PublishDate}"));
}

void AddIAuthor()
{
    var author = new Author() { FirstName = "Mehmet", LastName = "Babaoğlu" };

    _context.Authors.Add(author);
    _context.SaveChanges();
}

void GetAuthors()
{

    var authors = _context.Authors.ToList();
    authors.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
}
