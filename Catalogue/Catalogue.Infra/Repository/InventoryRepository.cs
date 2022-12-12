using Catalogue.Core.Contracts;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infra.Repository
{
    public class InventoryRepository:RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(CatalogueContext context):base(context)
        {

        }
    }
}
