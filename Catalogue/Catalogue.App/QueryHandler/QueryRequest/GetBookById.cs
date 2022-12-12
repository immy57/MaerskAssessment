using Catalogue.App.Models;
using Catalogue.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.QueryHandler.QueryRequest
{
    public class GetBookById:IRequest<BookBM>
    {
        public int Id { get; set; }
    }
}
