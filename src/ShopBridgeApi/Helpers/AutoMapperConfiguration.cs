using AutoMapper;
using ShopBridgeApi.Models;
using ShopBridgeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Helpers
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Product, ProductVM>();
        }
    }
}
