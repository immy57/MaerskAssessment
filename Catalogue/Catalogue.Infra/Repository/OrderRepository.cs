using Catalogue.Core.Contracts;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infra.Repository
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(CatalogueContext context):base(context)
        {

        }
    }
}
