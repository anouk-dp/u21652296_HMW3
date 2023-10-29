using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21652296_HMW3.Models
{
    
        public class BorrowsViewModel
        {
            public int borrowId { get; set; }
            public int studentId { get; set; }
            public string studentName { get; set; }
            public int bookId { get; set; }
            public string bookName { get; set; }
            public DateTime takenDate { get; set; }
            public DateTime broughtDate { get; set; }

            //public virtual books books { get; set; }
            //public virtual students students { get; set; }
        }
    
}