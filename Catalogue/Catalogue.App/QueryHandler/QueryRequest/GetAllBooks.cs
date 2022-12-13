using Catalogue.Core.Models;
using Catalogue.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.QueryHandler.QueryRequest
{
    public class GetAllBooks:IRequest<IList<BookBM>>
    {
    }
}
