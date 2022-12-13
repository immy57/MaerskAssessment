using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.Core.Models;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Core.Models.ResponseModel;

namespace Catalogue.App.CommandHandler
{
    public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemByIdCommand, RemoveCartItemResponse>
    {
        public IUnitOfWorks _unitOfWorks { get; set; }

        public RemoveCartItemHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task<RemoveCartItemResponse> Handle(RemoveCartItemByIdCommand request, CancellationToken cancellationToken)
        {
            RemoveCartItemResponse response = new RemoveCartItemResponse();

            var item=await _unitOfWorks.CartRepository.GetByCodition(x => x.Id == request.Id);
            if (item == null)
            {
                response.ErrorMessage = "Cart item is not available";
                return response;
            }

            await _unitOfWorks.CartRepository.RemoveItemByCondition(x => x.Id == request.Id);
            var isItemDeleted= await _unitOfWorks.SaveChangeAsync();
            if(isItemDeleted)
            {
                response.Message = "Item removed successfully";
            }
            return response;

           
        }
    }
}
