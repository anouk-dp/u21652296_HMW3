using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21652296_HMW3.Models
{
    public class StudentBookViewModel
    {
        public PagedList.IPagedList<students> Students { get; set; }
        public PagedList.IPagedList<BookViewModel> Books { get; set; }
    }
}