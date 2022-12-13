using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.Models
{
    public class OrderBM
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
