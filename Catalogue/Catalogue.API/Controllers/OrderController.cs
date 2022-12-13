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
    public class OrderController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllOrderResponse> GetAllOrders()
        {
            return await _mediator.Send(new GetAllOrder());

        }

        [HttpPost]
        public async Task<CreateOrderResponse> CreateOrder(CreateOrderCommand orderItem)
        {
            return await _mediator.Send(orderItem);
        }
    }
}
