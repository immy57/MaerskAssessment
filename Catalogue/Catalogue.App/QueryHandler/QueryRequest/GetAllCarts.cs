using Catalogue.Core.Models;
using Catalogue.Core.Models.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.QueryHandler.QueryRequest
{
    public class GetAllCarts:IRequest<GetAllCartResponse>
    {
    }
}
