using Catalogue.App.CommandHandler.CommandRequest;
using Catalogue.App.Models;
using Catalogue.App.QueryHandler.QueryRequest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public IMediator _mediator { get; set; }
        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<AddBookInventoryResponse> AddBookIntoInventory(AddBookIntoInventory addBookIntoInventory)
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
