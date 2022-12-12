using AutoMapper;
using Catalogue.App.Models;
using Catalogue.App.QueryHandler;
using Catalogue.App.QueryHandler.QueryRequest;
using Catalogue.Core;
using Catalogue.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.App.Test.QueryHandler
{
    class GetAllBookHandlerTest
    {
        Mock<IUnitOfWorks> _unitOfWorks;
        Mock<IMapper> _mapper;
        GetAllBookHandler getAllBookHandler;

        public GetAllBookHandlerTest()
        {
            _unitOfWorks = new Mock<IUnitOfWorks>();
            _mapper = new Mock<IMapper>();
            getAllBookHandler = new GetAllBookHandler(_unitOfWorks.Object, _mapper.Object);
        }

        [Test]
        public async Task GetAllBooksHanlderTest()
        {
            IList<BookBM> books = new List<BookBM>() { new BookBM()
            {
                Id=1,
                BookAuthor="xyz",
                BookPrice=12.34M,
                BookTitle="xyz"

            }
            };
            _mapper.Setup(x => x.Map(It.IsAny<IList<Book>>(), It.IsAny<IList<BookBM>>())).Returns(books.ToList());
            IList<Book> bookData = new List<Book>() { new Book()
            {
                Id=1,
                BookAuthor="xyz",
                BookPrice=12.34M,
                BookTitle="xyz"

            }
            };

            _unitOfWorks.Setup(x => x.BookRepository.GetAll()).Returns(Task.FromResult(bookData));
            var result = await getAllBookHandler.Handle(new GetAllBooks(), new System.Threading.CancellationToken());
            Assert.IsTrue(result.ToList().FirstOrDefault().BookAuthor == "xyz");

        }


    }
}
