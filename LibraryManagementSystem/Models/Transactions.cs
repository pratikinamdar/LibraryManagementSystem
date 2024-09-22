using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Transactions
    {

        [Key]
        public int TransactionId { get; set; }

        public int MemberId { get; set; }

        public int Isbn { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnData { get; set; }
    }

    public class TransactionsParams
    {
        public int MemberId { get; set; }

        public int Isbn { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnData { get; set; }
    }
}
