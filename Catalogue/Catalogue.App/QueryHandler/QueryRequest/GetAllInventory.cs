using Catalogue.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.QueryHandler.QueryRequest
{
    public class GetAllInventory:IRequest<List<InventoryBM>>
    {
    }
}
