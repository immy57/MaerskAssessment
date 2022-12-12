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
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
    {
      private IUnitOfWorks _unitOfWorks { get; set; }
        public CreateOrderHandler( IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            CreateOrderResponse response = new CreateOrderResponse();
           var inventoryItem =await  _unitOfWorks.InventoryRepository.GetByCodition(x => x.BookId == request.BookId);
            if (inventoryItem.Quantity < request.Quantity)
            {
                response.ErrorMessage = "Available quantity is not enough";
                return response;
            }
           await _unitOfWorks.OrderRepository.Add(new Core.Models.Order()
            {
                BookId = request.BookId,
                Quantity=request.Quantity
            });

            inventoryItem.Quantity = inventoryItem.Quantity - request.Quantity;
            await _unitOfWorks.InventoryRepository.Update(inventoryItem);
            var result= await _unitOfWorks.SaveChangeAsync();
            if(result)
                response.Message = "Order added successfully";
            return response;
        }
    }
}
