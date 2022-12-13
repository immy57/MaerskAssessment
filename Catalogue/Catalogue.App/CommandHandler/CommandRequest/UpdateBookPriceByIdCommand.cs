using Catalogue.Core.Models.ResponseModel;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.CommandHandler.CommandRequest
{
    public class UpdateBookPriceByIdCommand:IRequest<UpdateBookPriceResponse>
    {
        public decimal Price { get; set; }
        public int Id { get; set; }
    }
}
