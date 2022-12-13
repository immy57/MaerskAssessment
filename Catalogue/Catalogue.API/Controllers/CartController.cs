using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.Core.Models;
using Catalogue.App.QueryHandler.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogue.Core.Models.ResponseModel;

namespace Catalogue.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        public IMediator _mediator { get; set; }
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllCartResponse> GetAllCarts()
        {
            return await _mediator.Send(new GetAllCarts());

        }

        [HttpPost]
        public async Task<AddCartItemResponse> AddItemIntoCart(AddItemIntoCartCommand item)
        {
            return await _mediator.Send(item);
        }

        [HttpDelete]
        public async Task<RemoveCartItemResponse> RemoveCartItemById(RemoveCartItemByIdCommand removeItemDetails)
        {
           return await _mediator.Send(removeItemDetails);
        }
    }
}
