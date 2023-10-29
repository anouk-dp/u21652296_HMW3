using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using u21652296_HMW3.Models;
using PagedList;

namespace u21652296_HMW3.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(int? booksPage, int? studentPage)
        {
            StudentBookViewModel viewModel;
            int pageSize = 10;

            using (var context = new LibraryEntities())
            {
                viewModel = new StudentBookViewModel
                {
                    Students = context.students.OrderBy(s => s.studentId).ToPagedList((studentPage?? 1), pageSize),
                    Books = (from book in context.books
                             join author in context.authors on book.authorId equals author.authorId
                             join type in context.types on book.typeId equals type.typeId
                             join borrow in context.borrows on book.bookId equals borrow.bookId
                             select new BookViewModel
                             {
                                 BookId = book.bookId,
                                 Name = book.name,
                                 PageCount = book.pagecount ?? 0,
                                 Point = book.point ?? 0,
                                 Type = type.name,
                                 Author = author.name,
                                 Availibity = borrow.broughtDate == null ? "Out" : "Available"
                             }).Distinct().OrderBy(b => b.BookId).ToPagedList((booksPage ?? 1), pageSize)
                };
            }

            return View(viewModel);
        }
        private LibraryEntities db = new LibraryEntities();

 



        public async Task<ActionResult> About()
        {
            MyViewModel viewModel;

            using (var context = new LibraryEntities())
            {
                viewModel = new MyViewModel
                {
                    Authors = await context.authors.ToListAsync(),
                    Types = await context.types.ToListAsync(),
                    Borrows = await context.borrows.ToListAsync(),
                };
            }
            //Returned 'Merged View'
            return View(viewModel);
        }

        //public async Task<ActionResult> Contact()
        //{
        //    AuthorTypesBorrowViewModel viewModel;

        //    using (var context = new LibraryEntities())
        //    {
        //        viewModel = new AuthorTypesBorrowViewModel
        //        {
        //            authors = await context.authors.ToListAsync(),
        //            types =await context.types.ToListAsync(),
        //            borrows = await (from borrows in context.borrows
        //                       join books in context.books on borrows.bookId equals books.bookId
        //                       select new BorrowsViewModel
        //                       {
        //                           borrowId = borrows.borrowId,
        //                           studentId = borrows.studentId ?? 0,
        //                           bookId = borrows.bookId ?? 0,
        //                           bookName = books.name,
        //                           broughtDate = borrows.broughtDate ?? DateTime.MinValue,//handles null
        //                           takenDate = borrows.takenDate ?? DateTime.MinValue,


        //                       }).ToListAsync()
        //        };

        //    }

        //    return View(viewModel);

        //}
    }
}