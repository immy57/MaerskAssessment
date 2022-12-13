using Catalogue.Core.Models;
using Catalogue.Core.Models.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
    public class AddBookIntoInventoryCommand:IRequest<AddBookInventoryResponse>
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
