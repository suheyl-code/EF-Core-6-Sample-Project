
using PublisherData;
using PublisherDomain;

// Ensures Database is existed, if not will create it.
using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

SequenceOfSteps();

/// Program Start point method
void SequenceOfSteps()
{
    //GetAuthors();
    //AddIAuthor();
    //GetAuthors();
    //AddAuthorWithBooks();
    GetAuthorWithBooks();
}

void AddAuthorWithBooks()
{
    var author = new Author { FirstName = "Julie", LastName = "Larmen" };
    author.Books.Add(new Book { AuthorId = 2, Title = "Entity Framework 6 Basics", PublishDate = new DateTime(2019, 1, 12) });
    author.Books.Add(new Book { AuthorId = 2, Title = "Entity Framework 6 Advanced", PublishDate = new DateTime(2021, 3, 20) });

    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}


void GetAuthorWithBooks()
{
    using var context = new PubContext();
    var books = context.Books.ToList();
    var author = context.Authors.ToList();
    books.ForEach(x => Console.WriteLine($"{x.Author.FirstName} {x.Author.LastName}: {x.Title} --- {x.PublishDate}"));
}

void AddIAuthor()
{
    var author = new Author() { FirstName = "Mehmet", LastName = "Babaoğlu" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    authors.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));
}
