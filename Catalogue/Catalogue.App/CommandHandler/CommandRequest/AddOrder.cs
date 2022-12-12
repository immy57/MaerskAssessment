using Catalogue.App.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
    public class AddOrder:IRequest<AddOrderResponse>
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
