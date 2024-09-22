using LibraryManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController
    {

        private LibraryDatabase db;
        public TransactionsController(IConfiguration config)
        {
            db = new LibraryDatabase(config.GetConnectionString("connstr"));
        }

        [HttpPost("Transactions", Name = "PostTransactions")]

        public void PostTransactions(TransactionsParams transactionsInput)
        {
            var newTransaction = new Transactions() { MemberId=transactionsInput.MemberId, BorrowDate=transactionsInput.BorrowDate, Isbn = transactionsInput.Isbn, ReturnData= transactionsInput.BorrowDate.AddDays(7) };
            db.Transactions.Add(newTransaction);
            db.SaveChanges();
        }

        [HttpGet("Transactions", Name = "Transactions")]
        public IEnumerable<Transactions> GetTransactions()
        {
            return (from t in db.Transactions
                    select t);
        }

        [HttpGet("GetLateMembers", Name ="GetLateMembers")]

        public IEnumerable<LibraryMembersLate> GetLateMembers()
        {
            var l = (from t in db.Transactions
                     join m in db.LibraryMember on t.MemberId equals m.MemberId
                     join b in db.Book on t.Isbn equals b.Isbn
                     where t.ReturnData < DateTime.Now && m.Active == true
                     select new LibraryMembersLate
                     {
                         MemberName = m.MemberName,
                         BookTitle = b.Title,
                         BorrowDate = t.BorrowDate,
                         ReturnDate = t.ReturnData,
                     }).ToList();
            return l;
        }

        [HttpDelete ("Transactions", Name="DeleteTransactions")]

        public void DeleteTransactions(int id)
        {
            var transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
        }
    }
}
