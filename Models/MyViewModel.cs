using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace u21652296_HMW3.Models
{
    public class MyViewModel

    {    // Lists Holder
        public IEnumerable<students> Students { get; set; }
        public IEnumerable<books> Books { get; set; }
        public IEnumerable<authors> Authors { get; set; }
        public IEnumerable<borrows> Borrows { get; set; }
        public IEnumerable<types> Types { get; set; }
    }
}