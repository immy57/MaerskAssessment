using AutoMapper;
using Catalogue.App.Models;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.Profiler
{
    public class CartMapper:Profile
    {
        public CartMapper()
        {
            CreateMap<Cart, CartBM>().ReverseMap();
        }
       
    }
}
