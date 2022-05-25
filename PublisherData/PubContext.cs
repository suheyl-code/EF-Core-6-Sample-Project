using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherData
{
    public class PubContext : DbContext
    {
        private readonly string connectionString = @"Data Source=LENOVOTHINKBOOK\SQLEXPRESS;Initial Catalog=PublisherApp_Db;Integrated Security=True;";
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);   
        }
    }
}
