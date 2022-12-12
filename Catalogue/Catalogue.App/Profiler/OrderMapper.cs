using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Catalogue.App.Models;
using Catalogue.Core.Models;

namespace Catalogue.App.Profiler
{
    public class OrderMapper:Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderBM>().ReverseMap();
        }

    }
}
