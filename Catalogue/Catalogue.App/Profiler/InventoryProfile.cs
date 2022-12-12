using AutoMapper;
using Catalogue.App.Models;
using Catalogue.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogue.App.Profiler
{
    class InventoryProfile:Profile
    {
        public InventoryProfile()
        {

            CreateMap<Inventory, InventoryBM>();
        }
    }
}
