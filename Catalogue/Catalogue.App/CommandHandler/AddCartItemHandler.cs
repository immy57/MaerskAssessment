using AutoMapper;
using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.Core.Contracts;
using Catalogue.Core.Models;
using Catalogue.Core.Models.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.CommandHandler
{
    public class AddCartItemHandler : IRequestHandler<AddItemIntoCartCommand, AddCartItemResponse>
    {
        public IUnitOfWorks _unitOfWorks { get; set; }
        public IMapper _mapper { get; set; }
        public AddCartItemHandler(IUnitOfWorks unitOfWorks,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }
        public async Task<AddCartItemResponse> Handle(AddItemIntoCartCommand request, CancellationToken cancellationToken)
        {
            AddCartItemResponse response = new AddCartItemResponse();
            var isBookAvailable = await _unitOfWorks.BookRepository.GetByCodition(x => x.Id == request.BookId);
            if (isBookAvailable == null)
            {
                response.ErrorMessage = "Book is not available in store. Please add proper book";
                return response;
            }
            Cart cart = new Cart();

            var result = _mapper.Map(new CartBM() { BookId = request.BookId, Price = isBookAvailable.BookPrice, Quantity = request.Quantity, TotalCost = isBookAvailable.BookPrice * request.Quantity }, cart);
            await _unitOfWorks.CartRepository.Add(cart);
            var isItemAdded = await _unitOfWorks.SaveChangeAsync();
            if (isItemAdded)
                response.Message = "Item added to cart";
            return response;
        }
    }
}
