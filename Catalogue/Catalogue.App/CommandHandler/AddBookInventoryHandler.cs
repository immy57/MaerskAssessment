﻿using Catalogue.App.CommandHandler.CommandRequest;
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
    public class AddBookInventoryHandler : IRequestHandler<AddBookIntoInventory, AddBookInventoryResponse>
    {
        public IUnitOfWorks _unitOfWorks { get; set; }

        public AddBookInventoryHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task<AddBookInventoryResponse> Handle(AddBookIntoInventory request, CancellationToken cancellationToken)
        {
            AddBookInventoryResponse response = new AddBookInventoryResponse();

            var result = await _unitOfWorks.BookRepository.GetByCodition(x => x.Id == request.BookId);
            if (result == null)
            {
                response.ErrorMessage = "Book Id does not exist";
            }


           await _unitOfWorks.InventoryRepository.Add(new Core.Models.Inventory()
            {
                BookId = request.BookId,
                Quantity = request.Quantity

            });

            var isDataAddedSuccessfully= await _unitOfWorks.SaveChangeAsync();
            if (isDataAddedSuccessfully)
            {
                response.Message = "Data added to invenotry";
            }
            return response;
        }
    }
}