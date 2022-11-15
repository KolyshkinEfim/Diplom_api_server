using AutoMapper;
using test_crud.Models;

namespace test_crud
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FavoriteItem, FavoriteItemInfo>().ReverseMap();
            CreateMap<Headphones, ProductInfo>().ReverseMap();
            CreateMap<Microphones, ProductInfo>().ReverseMap();
            CreateMap<AcousticSystems, ProductInfo>().ReverseMap();
        }
    }
}
