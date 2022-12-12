using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalogue.App.Models;
using Catalogue.Core;

namespace Catalogue.App.Profiler
{
    public class BookProfiler:Profile
    {
        public BookProfiler()
        {
            CreateMap<Book, BookBM>();
        }

    }
}
