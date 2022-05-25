
using PublisherData;
using PublisherDomain;

// Ensures Database is existed, if not will create it.
using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}
GetAuthors();
AddIAuthor();
GetAuthors();

void AddIAuthor()
{
    var author = new Author() { FirstName = "Mehmeh", LastName = "Babaoğlu" };
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
