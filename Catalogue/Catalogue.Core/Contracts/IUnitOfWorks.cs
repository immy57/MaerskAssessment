using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Contracts
{
    public interface IUnitOfWorks
    {
        public IInventoryRepository InventoryRepository { get; }
        public ICartRepository CartRepository { get;  }
        public IBookRepository BookRepository { get;  }
        public IOrderRepository OrderRepository { get;  }

        public Task<bool> SaveChangeAsync();
    }
}
