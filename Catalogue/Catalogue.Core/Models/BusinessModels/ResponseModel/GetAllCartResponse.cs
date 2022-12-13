using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Core.Models.ResponseModel
{
    public class GetAllCartResponse:Base
    {
        public GetAllCartResponse()
        {
            Carts = new List<CartBM>();

        }

        public List<CartBM> Carts { get; set; }
    }
}
