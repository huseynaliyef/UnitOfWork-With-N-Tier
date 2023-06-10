using AutoMapper;
using N_Tier.BusinessLogic.Models.DTO.Product;
using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<AddProductUIDTO,Product>().ReverseMap();
            CreateMap<Product, GetProductUIDTO>().ReverseMap();
            CreateMap<UpdateProductUIDTO, Product>().ReverseMap();

        }
    }
}
