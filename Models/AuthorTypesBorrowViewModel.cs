using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21652296_HMW3.Models
{
    public class AuthorTypesBorrowViewModel
    {
        public PagedList.IPagedList<authors> authors { get; set; }
        public PagedList.IPagedList<types> types { get; set; }
        public PagedList.IPagedList<BorrowsViewModel> borrows { get; set; }
    }
}