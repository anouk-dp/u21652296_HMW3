using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace u21652296_HMW3.Models
{
    
        public class BookViewModel
        {
            public int BookId { get; set; }
            public string Name { get; set; }
            public int PageCount { get; set; }
            public int Point { get; set; }
            public string Type { get; set; }
            public string Author { get; set; }
            public string Availibity { get; set; }
        }

    
}