using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetNewsFeedListODTO
    {
        public int NewsFeedId { get; set; }
        public string Name { get; set; }
        public string NewsText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Market { get; set; }
        public string TagLine { get; set; }
        public bool RedFlag { get; set; }
        public int? UrlTableId { get; set; }
        public string URL { get; set; }
        public int Route { get; set; }
        public string Logo { get; set; }
    }
}