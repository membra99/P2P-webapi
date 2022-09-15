using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class PageODTO
    {
        public int PageId { get; set; }
        //public int SerpId { get; set; }
        //public Serp Serp { get; set; } Da li treba vratiti ceo serp?

        //public int ReviewId { get; set; }
        // int ReviewId { get; set; }  Da li treba vratiti ceo review?
        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }
        public string TypeName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Page_Title { get; set; }
        public string Content { get; set; }
    }
}
