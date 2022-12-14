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
        public UnitOfWorks(CatalogueContext context,IInventoryRepository inventoryRepository,
            ICartRepository cartRepository, IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            Context = context;
            InventoryRepository = inventoryRepository;
            CartRepository = cartRepository;
            BookRepository = bookRepository;
            OrderRepository = orderRepository;
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
