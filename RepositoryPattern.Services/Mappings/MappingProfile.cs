using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Mappings
{
    public class MappingProfile : Profile // Profile, AutoMapper'dan gelen eşleme içn kullandığımız sınftır. 
    {
        public MappingProfile() // CreateMap 
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            /*
             CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CreatedBy, source => source.MapFrom(source => source.Category)) //Specific Mapping
            .ForMember(dest => dest.UpdatedUser, source => source.MapFrom(source => source.Barcode > 0 ? true : false)) // Conditional Mapping
            .ReverseMap();
            */
        }
    }
}
