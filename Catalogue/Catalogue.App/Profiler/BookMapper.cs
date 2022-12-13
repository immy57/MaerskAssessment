using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalogue.Core.Models;
using Catalogue.Core;

namespace Catalogue.App.Profiler
{
    public class BookMapper:Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookBM>().ReverseMap();
        }

    }
}
