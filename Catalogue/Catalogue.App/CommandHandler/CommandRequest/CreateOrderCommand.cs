using Catalogue.App.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
    public class CreateOrderCommand:IRequest<CreateOrderResponse>
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
