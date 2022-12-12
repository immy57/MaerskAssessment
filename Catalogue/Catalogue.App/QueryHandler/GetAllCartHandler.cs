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
    public class GetAllCartHandler : IRequestHandler<GetAllCarts, GetAllCartResponse>
    {
        private IUnitOfWorks _unitOfWorks { get; set; }
        public IMapper _mapper { get; set; }
        public GetAllCartHandler(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
        }
        public async Task<GetAllCartResponse> Handle(GetAllCarts request, CancellationToken cancellationToken)
        {
            GetAllCartResponse response = new GetAllCartResponse();

            var result = await _unitOfWorks.CartRepository.GetAll();
            if (result.Count == 0)
                response.ErrorMessage = "There is no cart item availble";
            _mapper.Map(result, response.Carts);
            return response;

        }
    }
}
