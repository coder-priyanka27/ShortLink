using AutoMapper;
using ShortLink.Client.Data.ViewModels;
using ShortLink.Data.Models;

namespace ShortLink.Client.Data.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Url,GetUrlViewModel>().ReverseMap();
            CreateMap<User, GetUserViewModel>().ReverseMap();
        }
    }
}
