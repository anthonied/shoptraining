using AutoMapper;
using Domain;

namespace Shop.Api.Dtos
{
    public class DtoMappingProfile: Profile
    {
        public DtoMappingProfile()
        {

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
