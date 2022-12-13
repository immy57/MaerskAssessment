using AutoMapper;
using Catalogue.Core.Models;
using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Catalogue.Core.Models.ResponseModel;

namespace Catalogue.App.QueryHandler
{
    public class GetAllOrderHandler : IRequestHandler<GetAllOrder, GetAllOrderResponse>
    {
        private IUnitOfWorks _unitOfWorks { get; set; }
        public IMapper _mapper { get; set; }
        public GetAllOrderHandler(IUnitOfWorks unitOfWorks,IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }
        public async Task<GetAllOrderResponse> Handle(GetAllOrder request, CancellationToken cancellationToken)
        {
            GetAllOrderResponse response = new GetAllOrderResponse();

            var result = await _unitOfWorks.OrderRepository.GetAll();
            if (result.Count==0)
                response.ErrorMessage = "There is no order availble";
           _mapper.Map(result, response.Orders);
            return response;
        }
    }
}
