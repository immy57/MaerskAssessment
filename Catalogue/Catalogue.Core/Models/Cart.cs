using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Catalogue.Core.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public int BookId { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
