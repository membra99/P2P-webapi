using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class HomeSettingsIDTO
    {
        public int HomeSettingsId { get; set; }
        public int? Platforms { get; set; }
        public int? NewsUrl { get; set; }
        public string NewsUrlLink { get; set; }
        public int? ReviewUrl { get; set; }
        public string ReviewUrlLink { get; set; }
        public int? AcademyUrl { get; set; }
        public string AcademyUrlLink { get; set; }
        public int? BonusUrl { get; set; }
        public string BonusUrlLink { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public int? LanguageId { get; set; }
        public string Title { get; set; }
        public decimal? Returned { get; set; }
        public int? Investment { get; set; }
        public string TestimonialH2 { get; set; }
        public string FeaturedH2 { get; set; }
        public string Platform { get; set; }
        public List<SettingsAttributeIDTO> SettingsAttributes { get; set; }
    }
}