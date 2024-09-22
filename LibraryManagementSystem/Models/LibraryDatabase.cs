using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace LibraryManagementSystem.Models
{
    public class LibraryDatabase:DbContext
    {
        public string connstr;

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<LibraryMember> LibraryMember { get; set; }

        public DbSet<Transactions> Transactions { get; set; }
        public LibraryDatabase(string connstr) 
        {
            this.connstr = connstr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(connstr);
        }
    }
}
