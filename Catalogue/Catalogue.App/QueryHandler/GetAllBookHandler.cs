using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Catalogue.App.Models;
using AutoMapper;

namespace Catalogue.App.QueryHandler
{
    public class GetAllBookHandler : IRequestHandler<GetAllBooks, IList<BookBM>>
    {
        private IUnitOfWorks _unitOfWorks { get; set; }
        private IMapper _mapper { get; set; } 
        public GetAllBookHandler(IUnitOfWorks unitOfWorks ,IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;

        }
        public async Task<IList<BookBM>> Handle(GetAllBooks request, CancellationToken cancellationToken)
        {
            IList<BookBM> books = new List<BookBM>();
            var result= await _unitOfWorks.BookRepository.GetAll();
            return _mapper.Map(result, books);
          
        }
    }
}
