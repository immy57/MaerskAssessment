using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.Core.Models;
using Catalogue.Core.Models.ResponseModel;
using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IMediator _Mediator { get; set; }
        public BookController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetAllBooks")]
        public async Task<IList<BookBM>> GetAllBooks()
        {
            return await _Mediator.Send(new GetAllBooks());
        }

        [HttpPost]
        public async Task<bool> AddBook(AddBookCommand book)
        {
            return await _Mediator.Send(book);

        }

        [HttpGet]
        [ActionName("GetBookById")]
        public async Task<BookBM> GetBookById(int id)
        {
            return await _Mediator.Send(new GetBookById() {Id=id });
        }

        [HttpPut]
        public async Task<UpdateBookPriceResponse> UpdateBookPriceById(UpdateBookPriceByIdCommand updatePriceBasedOnTitleCommand)
        {
            return await _Mediator.Send(updatePriceBasedOnTitleCommand);
        }
    }
}
