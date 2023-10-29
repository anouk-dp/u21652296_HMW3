using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21652296_HMW3.Models
{
    public class StudentBookViewModelAgain
    {
        public List<students> Students { get; set; }
        public List<BookViewModel> Books { get; set; }
    }
}