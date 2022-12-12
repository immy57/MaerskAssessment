using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.App.Models.ResponseModel;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.CommandHandler
{
    public class UpdateBookPriceByIDCommandHandler : IRequestHandler<UpdateBookPriceByIdCommand, UpdateBookPriceResponse>
    {
        private IUnitOfWorks _unitOfWorks { get; set; }
        public UpdateBookPriceByIDCommandHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;

        }
        public async Task<UpdateBookPriceResponse> Handle(UpdateBookPriceByIdCommand request, CancellationToken cancellationToken)
        {
            UpdateBookPriceResponse response = new UpdateBookPriceResponse();
            var result = await _unitOfWorks.BookRepository.GetByCodition(x => x.Id == request.Id);
            if (result == null)
            {
                response.ErrorMessage = "Book does not exist";
                return response;

            }
            result.BookPrice = request.Price;


            await _unitOfWorks.BookRepository.Update(result);

            var saveResult = await _unitOfWorks.SaveChangeAsync();
            if (saveResult)
                response.Message = "Book price updated successfully";
            return response;
        }
    }
}
