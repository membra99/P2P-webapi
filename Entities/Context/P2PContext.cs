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

            });

            modelBuilder.Entity<ReviewAttribute>(entity =>
            {
                entity.HasKey(x => x.ReviewAttributeId);

                entity.HasOne(x => x.DataType)
                      .WithMany(x => x.ReviewAttributes)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            #endregion
        }
    }
}