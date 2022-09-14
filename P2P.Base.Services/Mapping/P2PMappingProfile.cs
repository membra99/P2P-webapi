using AutoMapper;
using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using P2P.DTO.Input;
using P2P.DTO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.Base.Services.Mapping
{
    public class P2PMappingProfile : Profile
    {
        public P2PMappingProfile()
        {
            #region MainData

            CreateMap<Testimonial, TestimonialODTO>()
                 .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
            CreateMap<TestimonialIDTO, Testimonial>();

            CreateMap<Language, LanguageODTO>();
            CreateMap<LanguageIDTO, Language>();

            CreateMap<DataType, DataTypeODTO>();
            CreateMap<DataTypeIDTO, DataType>();

            CreateMap<NavigationSettings, NavigationSettingsODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
            CreateMap<NavigationSettingsIDTO, NavigationSettings>();

            CreateMap<FooterSettings, FooterSettingsODTO>()
               .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.FacebookUrl, source => source.MapFrom(m => m.FS_FacebookUrl.URL))
               .ForMember(dest => dest.LinkedInUrl, source => source.MapFrom(m => m.FS_LinkedInUrl.URL))
               .ForMember(dest => dest.PodcastUrl, source => source.MapFrom(m => m.FS_PodcastUrl.URL))
               .ForMember(dest => dest.TwitterUrl, source => source.MapFrom(m => m.FS_TwitterUrl.URL))
               .ForMember(dest => dest.YoutubeUrl, source => source.MapFrom(m => m.FS_YoutubeUrl.URL));
            CreateMap<FooterSettingsIDTO, FooterSettings>();

            CreateMap<ReviewAttribute, ReviewAttributeODTO>()
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));
            CreateMap<ReviewAttributeIDTO, ReviewAttribute>();

            CreateMap<Links, LinkODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.Url, source => source.MapFrom(m => m.UrlTable.URL));
            CreateMap<LinkIDTO, Links>();

            CreateMap<UrlTable, UrlTableODTO>()
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));
            CreateMap<UrlTableIDTO, UrlTable>();

            CreateMap<Routes, RoutesODTO>()
              .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName))
              .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
              .ForMember(dest => dest.URL, source => source.MapFrom(m => m.UrlTable.URL));

            CreateMap<RoutesIDTO, Routes>();

            #endregion MainData
        }
    }
}