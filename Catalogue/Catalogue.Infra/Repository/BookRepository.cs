using Catalogue.Core;
using Catalogue.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.Infra
{
   public  class BookRepository: RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(CatalogueContext context):base(context)
        {

        }
    }
}
