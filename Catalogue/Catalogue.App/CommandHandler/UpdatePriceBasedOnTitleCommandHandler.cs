using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.CommandHandler
{
    public class UpdatePriceBasedOnTitleCommandHandler : IRequestHandler<UpdatePriceBasedOnTitleCommand, bool>
    {
        private IUnitOfWorks _unitOfWorks { get; set; }
        public UpdatePriceBasedOnTitleCommandHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;

        }
        public async Task<bool> Handle(UpdatePriceBasedOnTitleCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWorks.BookRepository.GetByCodition(x => x.BookTitle == request.Title);
           // if(result!=null)
             await _unitOfWorks.BookRepository.Update(result);
           return await _unitOfWorks.SaveChangeAsync();
        }
    }
}
