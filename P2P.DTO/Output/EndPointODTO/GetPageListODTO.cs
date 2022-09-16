using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class GetPageListODTO
    {
        public int PageId { get; set; }

        public int DataTypeId { get; set; }
        public string DataTypeName { get; set; }

        public string Page_Title { get; set; }
    }
}