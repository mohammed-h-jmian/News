using AutoMapper;
using News.Core.Dtos.ClassificationDtos;
using News.Core.Dtos.NewsDtos;
using News.Core.ViewModels;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.AutoMappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Classification, ClassificationViewModel>();
            CreateMap<CreateClassificationDto, Classification>();
            CreateMap<UpdateClassificationDto, Classification>();
            CreateMap<Classification, UpdateClassificationDto>();


            CreateMap<News.Data.Models.News, NewsViewModel>().ForMember(x => x.CreatedAt, x => x.MapFrom(x => x.CreatedAt.ToString()));
            //CreateMap<News.Data.Models.News, NewsViewModel>();
            CreateMap<CreateNewsDto, News.Data.Models.News>().ForMember(x => x.ImagePath, x => x.Ignore());
            CreateMap<UpdateNewsDto, News.Data.Models.News>().ForMember(x => x.ImagePath, x => x.Ignore());
            CreateMap<News.Data.Models.News, UpdateNewsDto>();




            //CreateMap<CreateClassificationDto, Classification>().ForMember(x => x.Image, x => x.Ignore());
            //CreateMap<UpdateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            //CreateMap<User, UpdateUserDto>().ForMember(x => x.ImageUrl, x => x.Ignore());

        }
    }
}
