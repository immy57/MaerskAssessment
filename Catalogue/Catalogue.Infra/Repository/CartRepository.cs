using Catalogue.Core.Contracts;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infra.Repository
{
    public class CartRepository: RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(CatalogueContext context):base(context)
        {

        }
    }
}
