﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class PageODTO
    {
        public int PageId { get; set; }
        public int? SerpId { get; set; }
        public string SerpTitle { get; set; }
        public string SerpDescription { get; set; }
        public string Subtitle { get; set; }
        public int? ReviewId { get; set; }
        public string Name { get; set; }
        public int? DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Page_Title { get; set; }
        public string Content { get; set; }
    }
}