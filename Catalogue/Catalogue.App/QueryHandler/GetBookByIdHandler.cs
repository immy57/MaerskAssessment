using AutoMapper;
using Catalogue.App.Models;
using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core;
using Catalogue.Core.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catalogue.App.QueryHandler
{
    public class GetBookByIdHandler : IRequestHandler<GetBookById, BookBM>
    {
        private IBookRepository _BookRepository { get; set; }
        private IMapper _Mapper { get; set; }
        public GetBookByIdHandler(IBookRepository bookRepository, IMapper mapper)
        {

            _BookRepository = bookRepository;
            _Mapper = mapper;
        }
        public async Task<BookBM> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            BookBM book = new BookBM();
            var result = await _BookRepository.GetByCodition(x => x.Id == request.Id);
            return _Mapper.Map(result, book);
        }
    }
}
