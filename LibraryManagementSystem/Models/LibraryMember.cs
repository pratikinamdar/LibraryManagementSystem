using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class LibraryMember
    {
        [Key]
        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public string ContactNumber { get; set; }

        public bool Active { get; set; }
    }


    public class LibraryMemberParams
    {
        public string MemberName { get; set; }

        public string ContactNumber { get; set; }

        public bool Active { get; set; }
    }


    public class LibraryMembersLate
    {
        public string MemberName { get; set;}
        public string BookTitle { get; set;}
        public DateTime BorrowDate { get; set;}
        public DateTime ReturnDate { get; set;}
    }
}
