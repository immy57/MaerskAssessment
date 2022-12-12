using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Catalogue.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual ICollection<Book> Book { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }

    }
}
