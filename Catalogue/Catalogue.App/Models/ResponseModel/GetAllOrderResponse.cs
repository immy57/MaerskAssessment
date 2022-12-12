using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.Models
{
    public class GetAllOrderResponse:Base
    {
        public GetAllOrderResponse()
        {
            this.Orders = new List<OrderBM>();
        }
        public List<OrderBM> Orders { get; set; }
    }
}
