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
    public class InventoryController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<AddBookInventoryResponse> AddBookIntoInventory(AddBookIntoInventoryCommand addBookIntoInventory)
        {
           return await  _mediator.Send(addBookIntoInventory);
        }

        [HttpGet]
        public async Task<List<InventoryBM>> GetAllInventory()
        {
            return await _mediator.Send(new GetAllInventory());
        }
    }
}
