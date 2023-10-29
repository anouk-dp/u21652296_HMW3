using GemBox.Spreadsheet;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using u21652296_HMW3.Models;

namespace u21652296_HMW3.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        public async Task<ActionResult> Index()
        {
            StudentBookViewModelAgain viewModel;

            using (var context = new LibraryEntities())
            {
       

                var allBooks = (from book in context.books
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
                                }).Distinct().OrderBy(b => b.BookId).ToList();

                viewModel = new StudentBookViewModelAgain
                {
                 
                    Books = allBooks
                };
            }

            return View(viewModel);
        }

        //public ActionResult GenerateReport()
        //{
            
        //    var doc = new pdf();
        //    var canvas = document.getElementById('myChart');
        //    var imageData = canvas.toDataURL('image/png');
        //    doc.addImage(imageData, 'PNG', 10, 10, 100, 80);


        //    byte[] pdfData = doc.output();
        //    return File(pdfData, "application/pdf", "report.pdf");
        //}

    }
}