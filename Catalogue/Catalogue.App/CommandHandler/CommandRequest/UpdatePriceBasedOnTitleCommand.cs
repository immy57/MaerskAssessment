using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
    public class UpdatePriceBasedOnTitleCommand:IRequest<bool>
    {
        public decimal Price { get; set; }
        public string Title { get; set; }
    }
}
