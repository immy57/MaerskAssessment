using Catalogue.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infra.Repository
{
    public class UnitOfWorks : IUnitOfWorks
    {
        public CatalogueContext Context { get; set; }
        public UnitOfWorks(CatalogueContext context)
        {
            Context = context;
            InventoryRepository = new InventoryRepository(context);
            CartRepository = new CartRepository(context);
            BookRepository = new BookRepository(context);
            OrderRepository = new OrderRepository(context);
        }
        public IInventoryRepository InventoryRepository { get; }

        public ICartRepository CartRepository { get; }

        public IBookRepository BookRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public async Task<bool> SaveChangeAsync()
        {
            return await Context.SaveChangesAsync() > 0;           
        }
    }
}
