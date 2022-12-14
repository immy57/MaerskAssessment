using AutoMapper;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.Profiler
{
    class InventoryMapper:Profile
    {
        public InventoryMapper()
        {

            CreateMap<Inventory, InventoryBM>().ReverseMap();
        }
    }
}
