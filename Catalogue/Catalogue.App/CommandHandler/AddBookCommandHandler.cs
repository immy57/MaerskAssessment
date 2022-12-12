using AutoMapper;
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
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, bool>
    {
        private IUnitOfWorks _unitOfWroks { get; set; }
        private IMapper _Mapper { get; set; }
        public AddBookCommandHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWroks = unitOfWorks;

        }
        public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
           await  _unitOfWroks.BookRepository.Add(new Core.Book() {
                BookTitle=request.BookTitle,
                BookAuthor=request.BookAuthor,
                BookPrice=request.BookPrice
            });

            return await _unitOfWroks.SaveChangeAsync();
        }
    }
}
