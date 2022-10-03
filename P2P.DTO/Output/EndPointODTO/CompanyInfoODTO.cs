using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output.EndPointODTO
{
    public class CompanyInfoODTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? LiveChat { get; set; }
        public string OpeningHours { get; set; }
        public int?[] SocialMedia { get; set; }
    }
}