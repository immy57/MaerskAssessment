using AutoMapper;
using Catalogue.App.Models;
using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.QueryHandler
{
    class GetAllInventoryHandler : IRequestHandler<GetAllInventory, List<InventoryBM>>
    {
        public IUnitOfWorks _unitOfWorks { get; set; }
        public IMapper _mapper { get; set; }
        public GetAllInventoryHandler(IUnitOfWorks unitOfWorks,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWorks = unitOfWorks;
        }
        public async Task<List<InventoryBM>> Handle(GetAllInventory request, CancellationToken cancellationToken)
        {
            List<InventoryBM> inventories = new List<InventoryBM>();
            var result = await _unitOfWorks.InventoryRepository.GetAll();
           return _mapper.Map(result, inventories);

        }
    }
}
