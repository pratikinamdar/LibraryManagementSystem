using LibraryManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryMemberController
    {

        private LibraryDatabase db;
        public LibraryMemberController(IConfiguration config)
        {
            db = new LibraryDatabase(config.GetConnectionString("connstr"));
        }

        [HttpPost("LibraryMember", Name = "PostLibraryMember")]

        public void PostLibraryMember(LibraryMemberParams libraryMemberInput)
        {
            var newLibraryMember = new LibraryMember() { MemberName=libraryMemberInput.MemberName, ContactNumber = libraryMemberInput.ContactNumber, Active=libraryMemberInput.Active };
            db.LibraryMember.Add(newLibraryMember);
            db.SaveChanges();
        }

        [HttpGet("LibraryMember", Name = "GetLibraryMember")]
        public IEnumerable<LibraryMember> GetLibraryMembers()
        {
            return (from l in db.LibraryMember
                    select l);
        }
    }
}
