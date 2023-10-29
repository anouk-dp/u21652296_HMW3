using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using u21652296_HMW3.Models;

namespace u21652296_HMW3.Controllers
{
    public class MaintainController : Controller
    {
        // GET: Maintain
        public async Task<ActionResult> Index(int? authorPage, int? typePage, int? borrowPage)
        {

            AuthorTypesBorrowViewModel viewModel;
            int pageSize = 10;
            using (var context = new LibraryEntities())
            {
                viewModel = new AuthorTypesBorrowViewModel
                {
                    authors = context.authors.OrderBy(a => a.authorId).ToPagedList((authorPage ?? 1), pageSize),
                    types = context.types.OrderBy(t => t.typeId).ToPagedList((typePage ?? 1), pageSize),
                    borrows = (from borrow in context.borrows
                                     join student in context.students on borrow.studentId equals student.studentId
                                     join book in context.books on borrow.bookId equals book.bookId
                                     select new BorrowsViewModel
                                     {
                                         bookId = book.bookId,
                                         bookName = book.name,
                                         borrowId = borrow.borrowId,
                                         studentId = student.studentId,
                                         studentName = student.name,
                                         broughtDate = (DateTime)(borrow.broughtDate),
                                         takenDate = (DateTime)(borrow.takenDate)
                                     }).Distinct().OrderBy(b => b.borrowId).ToPagedList((borrowPage ?? 1), pageSize)
                };
            }

            return View(viewModel);
        }
    }
}