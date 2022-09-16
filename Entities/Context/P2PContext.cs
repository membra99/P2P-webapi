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
        public DbSet<Links> Links { get; set; }
        public DbSet<CashBack> CashBacks { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Serp> Serps { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<FaqTitle> FaqTitles { get; set; }
        public DbSet<FaqList> FaqLists { get; set; }
        public DbSet<Page> Pages { get; set; }

        #endregion MainData

        private void P2PModelCreating(ModelBuilder modelBuilder)
        {
            #region MainData

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
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_InstagramUrl)
                    .WithMany(x => x.Rev_InstagramUrls)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_LinkedInUrl)
                    .WithMany(x => x.Rev_LinkedIdUrls)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_TwitterUrl)
                    .WithMany(x => x.Rev_TwitterUrls)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_YoutubeUrl)
                    .WithMany(x => x.Rev_YoutubeUrls)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Rev_ReportLink)
                    .WithMany(x => x.Rev_ReportLinks)
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

                entity.HasOne(x => x.Review)
                    .WithMany(x => x.Routes)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            #endregion MainData
        }
    }
}