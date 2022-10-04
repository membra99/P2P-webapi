using AutoMapper;
using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.DTO.Output.EndPointODTO;
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

            CreateMap<NavigationSettings, NavigationSettingsODTO>();
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
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));

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
              .ForMember(dest => dest.URL, source => source.MapFrom(m => m.UrlTable.URL))
              .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));

            CreateMap<RoutesIDTO, Routes>();

            CreateMap<CashBack, CashBackODTO>()
               .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));
            CreateMap<CashBackIDTO, CashBack>();

            CreateMap<CashBack, GetCashbackCampOfferODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));

            CreateMap<Serp, SerpODTO>()
               .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));
            CreateMap<SerpIDTO, Serp>();

            CreateMap<Review, ReviewODTO>()
               .ForMember(dest => dest.Languagename, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
               .ForMember(dest => dest.FacebookUrl, source => source.MapFrom(m => m.Rev_FacebookUrl.Rev_FacebookUrls))
               .ForMember(dest => dest.InstagramUrl, source => source.MapFrom(m => m.Rev_InstagramUrl.Rev_InstagramUrls))
               .ForMember(dest => dest.LinkedInUrl, source => source.MapFrom(m => m.Rev_LinkedInUrl.Rev_LinkedIdUrls))
               .ForMember(dest => dest.TwitterUrl, source => source.MapFrom(m => m.Rev_TwitterUrl.Rev_TwitterUrls))
               .ForMember(dest => dest.YoutubeUrl, source => source.MapFrom(m => m.Rev_YoutubeUrl.Rev_YoutubeUrls))
               .ForMember(dest => dest.ReportLink, source => source.MapFrom(m => m.Rev_ReportLink.Rev_ReportLinks));

            CreateMap<ReviewIDTO, Review>();

            CreateMap<FaqTitle, FaqTitleODTO>()
                .ForMember(dest => dest.Page_Title, source => source.MapFrom(m => m.Page.PageTitle))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));
            CreateMap<FaqTitleIDTO, FaqTitle>();

            CreateMap<FaqTitle, GetFaqTitleByReviewIdODTO>();
            CreateMap<FaqTitle, GetFaqTitleByPageIdODTO>();

            CreateMap<FaqList, FaqListODTO>()
                .ForMember(dest => dest.FaqListId, source => source.MapFrom(m => m.FaqPageListId));
            CreateMap<FaqListIDTO, FaqList>();

            CreateMap<Page, PageODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name))
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));
            CreateMap<PageIDTO, Page>();

            CreateMap<Page, GetPageListODTO>()
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));

            CreateMap<Academy, AcademyODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
                .ForMember(dest => dest.Url, source => source.MapFrom(m => m.UrlTable.URL));
            CreateMap<AcademyIDTO, Academy>();

            CreateMap<PagesSettings, PagesSettingsODTO>()
              .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
              .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
              .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name))
              .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));

            CreateMap<PagesSettingsIDTO, PagesSettings>();

            CreateMap<NewsFeed, NewsFeedODTO>()
             .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
             .ForMember(dest => dest.URL, source => source.MapFrom(m => m.UrlTable.URL))
             .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));

            CreateMap<NewsFeedIDTO, NewsFeed>();

            CreateMap<PageArticles, PageArticlesODTO>()
            .ForMember(dest => dest.Title, source => source.MapFrom(m => m.Academy.Title))
            .ForMember(dest => dest.PageTitle, source => source.MapFrom(m => m.Page.PageArticles));

            CreateMap<PagesArticlesIDTO, PageArticles>();

            CreateMap<HomeSettings, HomeSettingsODTO>()
               .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name))
               .ForMember(dest => dest.NewsUrlLink, source => source.MapFrom(m => m.NewsUrls.URL))
               .ForMember(dest => dest.BonusUrlLink, source => source.MapFrom(m => m.BonusUrls.URL))
               .ForMember(dest => dest.AcademyUrlLink, source => source.MapFrom(m => m.AcademyUrls.URL))
               .ForMember(dest => dest.ReviewUrlLink, source => source.MapFrom(m => m.ReviewUrls.URL));
            CreateMap<HomeSettingsIDTO, HomeSettings>();

            CreateMap<SettingsAttribute, SettingsAttributeODTO>()
               .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName))
               .ForMember(dest => dest.SettingsDataTypeName, source => source.MapFrom(m => m.SettingsDataType.DataTypeName))
               .ForMember(dest => dest.Index, source => source.MapFrom(m => m.Index));

            CreateMap<SettingsAttributeIDTO, SettingsAttribute>();

            CreateMap<AboutSettings, AboutSettingsODTO>()
                .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
                .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription));
            CreateMap<AboutSettingsIDTO, AboutSettings>();

            CreateMap<Category, CategoryODTO>();
            CreateMap<CategoryIDTO, Category>();

            CreateMap<Blog, BlogODTO>()
                .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
                .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
                .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle));

            #endregion MainData

            #region Users

            CreateMap<User, UserODTO>();
            CreateMap<UserIDTO, User>();

            #endregion Users
        }
    }
}