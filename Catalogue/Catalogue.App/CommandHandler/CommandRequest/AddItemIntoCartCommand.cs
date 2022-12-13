using Catalogue.Core.Models;
using Catalogue.Core.Models.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
   public class AddItemIntoCartCommand:IRequest<AddCartItemResponse>
    {
        public int Quantity { get; set; }
        public int BookId { get; set; }
    }
}
