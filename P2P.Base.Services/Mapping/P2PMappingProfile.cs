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

            CreateMap<UrlLanguages, UrlLanguagesODTO>();

            CreateMap<Crypto, CryptoODTO>();
            CreateMap<CryptoODTO, Crypto>();


            CreateMap<ImagesInfo, ImagesInfoODTO>()
                .ForMember(dest => dest.Aws, source => source.MapFrom(m => m.UrlTable.URL));
            CreateMap<ImagesInfoIDTO, ImagesInfo>();

            CreateMap<Author, AuthorODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName));
            CreateMap<AuthorIDTO, Author>();

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
              .ForMember(dest => dest.URL, source => source.MapFrom(m => m.UrlTable.URL));

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
               .ForMember(dest => dest.FacebookUrlName, source => source.MapFrom(m => m.Rev_FacebookUrl.URL))
               .ForMember(dest => dest.InstagramUrlName, source => source.MapFrom(m => m.Rev_InstagramUrl.URL))
               .ForMember(dest => dest.LinkedInUrlName, source => source.MapFrom(m => m.Rev_LinkedInUrl.URL))
               .ForMember(dest => dest.TwitterUrlName, source => source.MapFrom(m => m.Rev_TwitterUrl.URL))
               .ForMember(dest => dest.YoutubeUrlName, source => source.MapFrom(m => m.Rev_YoutubeUrl.URL))
               .ForMember(dest => dest.ReportUrlName, source => source.MapFrom(m => m.Rev_ReportLink.URL))
               .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
               .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
               .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle));

            CreateMap<ReviewIDTO, Review>();

            CreateMap<FaqTitle, FaqTitleODTO>()
                .ForMember(dest => dest.Page_Title, source => source.MapFrom(m => m.Page.PageTitle))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name));
            CreateMap<FaqTitleIDTO, FaqTitle>();

            CreateMap<FaqTitle, GetFaqTitleByReviewIdODTO>();
            CreateMap<FaqTitle, GetFaqTitleByPageIdODTO>();
            CreateMap<FaqTitle, GetFaqTitleByBlogIdODTO>();

            CreateMap<FaqList, FaqListODTO>()
                .ForMember(dest => dest.FaqListId, source => source.MapFrom(m => m.FaqPageListId));
            CreateMap<FaqListIDTO, FaqList>();

            CreateMap<Page, PageODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.Name, source => source.MapFrom(m => m.Review.Name))
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName))
                .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle))
                .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
                .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription));
            CreateMap<PageIDTO, Page>();

            CreateMap<Page, GetPageListODTO>()
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));

            CreateMap<Academy, AcademyODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.URL, source => source.MapFrom(m => m.UrlTable.URL));
            CreateMap<AcademyIDTO, Academy>();

            CreateMap<PagesSettings, PagesSettingsODTO>()
              .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
              .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
              .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
              .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle))
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
               .ForMember(dest => dest.NewsUrlLink, source => source.MapFrom(m => m.NewsUrls.URL))
               .ForMember(dest => dest.BonusUrlLink, source => source.MapFrom(m => m.BonusUrls.URL))
               .ForMember(dest => dest.AcademyUrlLink, source => source.MapFrom(m => m.AcademyUrls.URL))
               .ForMember(dest => dest.ReviewUrlLink, source => source.MapFrom(m => m.ReviewUrls.URL))
               .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
               .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
               .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle));
            CreateMap<HomeSettingsIDTO, HomeSettings>();

            CreateMap<SettingsAttribute, SettingsAttributeODTO>()
               .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
               .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName))
               .ForMember(dest => dest.SettingsDataTypeName, source => source.MapFrom(m => m.SettingsDataType.DataTypeName))
               .ForMember(dest => dest.Url, source => source.MapFrom(m => m.Url.URL))
               .ForMember(dest => dest.Index, source => source.MapFrom(m => m.Index));

            CreateMap<SettingsAttributeIDTO, SettingsAttribute>();

            CreateMap<AboutSettings, AboutSettingsODTO>()
                .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
                .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
                .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle));
            CreateMap<AboutSettingsIDTO, AboutSettings>();

            CreateMap<Category, CategoryODTO>();
            CreateMap<CategoryIDTO, Category>();

            
              

            CreateMap<Blog, BlogODTO>()
               .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
               .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
               .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(m => m.Category.CategoryName));
            CreateMap<BlogIDTO, Blog>();

            CreateMap<Blog, BlogContetntODTO>()
             .ForMember(dest => dest.SerpTitle, source => source.MapFrom(m => m.Serp.SerpTitle))
               .ForMember(dest => dest.SerpDescription, source => source.MapFrom(m => m.Serp.SerpDescription))
               .ForMember(dest => dest.Subtitle, source => source.MapFrom(m => m.Serp.Subtitle))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(m => m.Category.CategoryName));

            #endregion MainData

            #region Users

            CreateMap<User, UserODTO>();
            CreateMap<UserIDTO, User>();

            CreateMap<Role, RoleODTO>();
            CreateMap<RoleIDTO, Role>();

            CreateMap<Permission, PermissionODTO>()
                .ForMember(dest => dest.LanguageName, source => source.MapFrom(m => m.Language.LanguageName))
                .ForMember(dest => dest.RoleName, source => source.MapFrom(m => m.Role.RoleName))
                .ForMember(dest => dest.Username, source => source.MapFrom(m => m.User.Username))
                .ForMember(dest => dest.DataTypeName, source => source.MapFrom(m => m.DataType.DataTypeName));
            CreateMap<PermissionIDTO, Permission>();

            #endregion Users
        }
    }
}