using LibraryManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {

        private LibraryDatabase db;
        public BookController(IConfiguration config) 
        {
             db = new LibraryDatabase(config.GetConnectionString("connstr"));
        }

        [HttpPost("Books", Name = "PostBooks")]

        public void PostBooks(BookParams bookInput)
        {
            var newBook = new Book() {Title = bookInput.Title, Genre=bookInput.Genre, Language = bookInput.Language, Publisher = bookInput.Publisher, PublicationYear = bookInput.PublicationYear };
            db.Book.Add(newBook);
            db.SaveChanges();
        }

        [HttpGet("Books", Name="GetBooks")]
        public IEnumerable<Book> GetBooks() 
        {
            return (from b in db.Book
                    select b);
        }

        [HttpDelete("Books/{id}", Name = "DeleteBooks")]
        public void DeleteBooks(int id)
        {

            var auth = from a in db.Author
                       where a.Isbn == id
                       select a;
            foreach (var a in auth)
            {
                db.Author.Remove(a);
            }
            db.SaveChanges();
            var trans = from t in db.Transactions
                        where t.Isbn == id
                        select t;
            foreach (var t in trans)
            {
                db.Transactions.Remove(t);
            }
            db.SaveChanges();

            var book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();

        }

    }


}
