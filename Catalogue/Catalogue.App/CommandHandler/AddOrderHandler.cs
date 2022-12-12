using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.App.Models;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.CommandHandler
{
    public class AddOrderHandler : IRequestHandler<AddOrder, AddOrderResponse>
    {
      private IUnitOfWorks _unitOfWorks { get; set; }
        public AddOrderHandler( IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task<AddOrderResponse> Handle(AddOrder request, CancellationToken cancellationToken)
        {
            AddOrderResponse response = new AddOrderResponse();
           var result =await  _unitOfWorks.InventoryRepository.GetByCodition(x => x.BookId == request.BookId);
            if (result.Quantity < request.Quantity)
            {
                response.ErrorMessage = "Available quantity is not enough";
                return response;
            }
           await _unitOfWorks.OrderRepository.Add(new Core.Models.Order()
            {
                BookId = request.BookId,
                Quantity=request.Quantity
            });

            result.Quantity = result.Quantity - request.Quantity;
            await _unitOfWorks.InventoryRepository.Update(result);
            await _unitOfWorks.SaveChangeAsync();
            response.Message = "Order added successfully";
            return response;
        }
    }
}
