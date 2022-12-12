using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public decimal BookPrice { get; set; }
 

    }
}
