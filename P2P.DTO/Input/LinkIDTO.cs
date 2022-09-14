using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class LinkIDTO
    {
        public int LinkId { get; set; }

        //public int UrlTableId { get; set; }
        public int LanguageId { get; set; }

        public string Key { get; set; }
    }
}