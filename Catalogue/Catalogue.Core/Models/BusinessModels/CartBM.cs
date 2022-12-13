using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.Models
{
    public class CartBM
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public int BookId { get; set; }
    }
}
