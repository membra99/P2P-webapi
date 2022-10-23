using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public partial class MainContext : DbContext
    {
        #region MainData

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ReviewAttribute> ReviewAttributes { get; set; }
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<NavigationSettings> NavigationSettings { get; set; }
        public DbSet<FooterSettings> FooterSettings { get; set; }
        public DbSet<UrlTable> UrlTables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<CashBack> CashBacks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Serp> Serps { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<FaqTitle> FaqTitles { get; set; }
        public DbSet<FaqList> FaqLists { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<PagesSettings> PagesSettings { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        public DbSet<PageArticles> PageArticles { get; set; }
        public DbSet<HomeSettings> HomeSettings { get; set; }
        public DbSet<AboutSettings> AboutSettings { get; set; }
        public DbSet<SettingsAttribute> SettingsAttributes { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        #endregion MainData

        private void P2PModelCreating(ModelBuilder modelBuilder)
        {
            #region MainData

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.UserId);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(x => x.PermissionId);

                entity.HasOne(x => x.Language)
                      .WithMany(x => x.Permissions)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                      .WithMany(x => x.Permissions)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Role)
                      .WithMany(x => x.Permissions)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DataType)
                      .WithMany(x => x.Permissions)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.RoleId);
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.HasKey(x => x.TestimonialId);

                entity.HasOne(x => x.Language)
                      .WithMany(x => x.Testimonials)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(x => x.LanguageId);

                entity.HasIndex(x => x.LanguageName);
            });

            modelBuilder.Entity<DataType>(entity =>
            {
                entity.HasKey(x => x.DataTypeId);
            });

            modelBuilder.Entity<NavigationSettings>(entity =>
            {
                entity.HasKey(x => x.NavigationSettingsId);

                entity.HasOne(x => x.Language)
                      .WithMany(x => x.NavigationSettings)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.HomeRouteLink)
                     .WithMany(x => x.HomeRouteLinks)
                     .HasForeignKey(x => x.HomeRoute)
                     .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.BonusRouteLink)
                     .WithMany(x => x.BonusRouteLinks)
                     .HasForeignKey(x => x.BonusRoute)
                     .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AcademyRouteLink)
                     .WithMany(x => x.AcademyRouteLinks)
                     .HasForeignKey(x => x.AcademyRoute)
                     .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.ReviewsRouteLink)
                    .WithMany(x => x.ReviewsRouteLinks)
                    .HasForeignKey(x => x.ReviewsRoute)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.NewsRouteLink)
                    .WithMany(x => x.NewsRouteLinks)
                    .HasForeignKey(x => x.NewsRoute)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FooterSettings>(entity =>
            {
                entity.HasKey(x => x.FooterSettingsId);

                entity.HasOne(x => x.Language)
                      .WithMany(x => x.FooterSettings)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.FS_FacebookUrl)
                      .WithMany(x => x.FacebookUrls)
                      .HasForeignKey(x => x.FacebookLink)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.FS_LinkedInUrl)
                      .WithMany(x => x.LinkedInUrls)
                      .HasForeignKey(x => x.LinkedInLink)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.FS_PodcastUrl)
                      .WithMany(x => x.PodcastUrls)
                      .HasForeignKey(x => x.PodcastLink)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.FS_TwitterUrl)
                      .WithMany(x => x.TwitterUrls)
                      .HasForeignKey(x => x.TwitterLink)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.FS_YoutubeUrl)
                      .WithMany(x => x.YoutubeUrls)
                      .HasForeignKey(x => x.YoutubeLink)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ReviewAttribute>(entity =>
            {
                entity.HasKey(x => x.ReviewAttributeId);

                entity.HasOne(x => x.DataType)
                      .WithMany(x => x.ReviewAttributes)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Review)
                      .WithMany(x => x.ReviewAttribute)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Links>(entity =>
            {
                entity.HasKey(x => x.LinkId);

                entity.HasOne(x => x.Language)
                       .WithMany(x => x.Links)
                       .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.UrlTable)
                       .WithMany(x => x.Links)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UrlTable>(entity =>
            {
                entity.HasKey(x => x.UrlTableId);

                entity.HasOne(x => x.DataType)
                      .WithMany(x => x.UrlTables)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CashBack>(entity =>
            {
                entity.HasKey(x => x.CashBackId);

                entity.HasOne(x => x.Review)
                    .WithMany(x => x.CashBacks)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.CashBacks)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FaqTitle>(entity =>
            {
                entity.HasKey(x => x.FaqTitleId);

                entity.HasOne(x => x.Page)
                      .WithMany(x => x.FaqTitles)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Review)
                      .WithMany(x => x.FaqTitles)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Blog)
                    .WithMany(x => x.FaqTitles)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FaqList>(entity =>
            {
                entity.HasKey(x => x.FaqPageListId);

                entity.HasOne(x => x.FaqTitle)
                    .WithMany(x => x.FaqLists)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Serp>(entity =>
            {
                entity.HasKey(x => x.SerpId);

                entity.HasOne(x => x.DataType)
                      .WithMany(x => x.Serps)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(x => x.PageId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.Pages)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DataType)
                    .WithMany(x => x.Pages)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Review)
                    .WithMany(x => x.Pages)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Serp)
                    .WithMany(x => x.Pages)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(x => x.ReviewId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.Reviews)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_FacebookUrl)
                    .WithMany(x => x.Rev_FacebookUrls)
                    .HasForeignKey(x => x.FacebookUrl)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_InstagramUrl)
                    .WithMany(x => x.Rev_InstagramUrls)
                    .HasForeignKey(x => x.InstagramUrl)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_LinkedInUrl)
                    .WithMany(x => x.Rev_LinkedIdUrls)
                    .HasForeignKey(x => x.LinkedInUrl)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_TwitterUrl)
                    .WithMany(x => x.Rev_TwitterUrls)
                    .HasForeignKey(x => x.TwitterUrl)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_YoutubeUrl)
                    .WithMany(x => x.Rev_YoutubeUrls)
                    .HasForeignKey(x => x.YoutubeUrl)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_ReportLink)
                    .WithMany(x => x.Rev_ReportLinks)
                    .HasForeignKey(x => x.ReportLink)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Serp)
                   .WithMany(x => x.Reviews)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.HasKey(x => x.RoutesId);

                entity.HasOne(x => x.UrlTable)
                    .WithMany(x => x.Routes)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Academy>(entity =>
            {
                entity.HasKey(x => x.AcademyId);

                entity.HasOne(x => x.UrlTable)
                    .WithMany(x => x.Academies)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.Academies)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Serp)
                    .WithMany(x => x.Academies)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PagesSettings>(entity =>
            {
                entity.HasKey(x => x.PagesSettingsId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.PagesSettings)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DataType)
                        .WithMany(x => x.PagesSettings)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Serp)
                    .WithMany(x => x.PagesSettings)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<NewsFeed>(entity =>
            {
                entity.HasKey(x => x.NewsFeedId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.NewsFeeds)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.UrlTable)
                        .WithMany(x => x.NewsFeeds)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Review)
                       .WithMany(x => x.NewsFeeds)
                       .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<PageArticles>(entity =>
            {
                entity.HasKey(x => x.PageArticleId);

                entity.HasOne(x => x.Academy)
                    .WithMany(x => x.PageArticles)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Page)
                        .WithMany(x => x.PageArticles)
                        .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HomeSettings>(entity =>
            {
                entity.HasKey(x => x.HomeSettingsId);

                entity.HasOne(x => x.Serp)
                        .WithMany(x => x.HomeSettings)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Language)
                        .WithMany(x => x.HomeSettings)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.NewsUrls)
                        .WithMany(x => x.NewsUrls)
                        .HasForeignKey(x => x.NewsUrl)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.ReviewUrls)
                       .WithMany(x => x.ReviewUrls)
                       .HasForeignKey(x => x.ReviewUrl)
                       .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.AcademyUrls)
                       .WithMany(x => x.AcademyUrls)
                       .HasForeignKey(x => x.AcademyUrl)
                       .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.BonusUrls)
                       .WithMany(x => x.BonusUrls)
                       .HasForeignKey(x => x.BonusUrl)
                       .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AboutSettings>(entity =>
            {
                entity.HasKey(x => x.AboutSettingsId);

                entity.HasOne(x => x.Serp)
                    .WithMany(x => x.AboutSettings)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.AboutSettings)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.CategoryId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.Categories)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SettingsAttribute>(entity =>
            {
                entity.HasKey(x => x.SettingsAttributeId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.SettingsAttributes)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.DataType)
                    .WithMany(x => x.DataTypes)
                    .HasForeignKey(x => x.DataTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SettingsDataType)
                    .WithMany(x => x.SettingsDataTypes)
                    .HasForeignKey(x => x.SettingsDataTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Url)
                      .WithMany(x => x.SettingsAttributes)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(x => x.BlogId);

                entity.HasOne(x => x.Language)
                    .WithMany(x => x.Blogs)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.User)
                    .WithMany(x => x.Blogs)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Serp)
                    .WithMany(x => x.Blogs)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Blogs)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            #endregion MainData
        }
    }
}