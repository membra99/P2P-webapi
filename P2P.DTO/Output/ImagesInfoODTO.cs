using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Output
{
    public class ImagesInfoODTO
    {
        public int ImageId { get; set; }
        public string AltText { get; set; }
        public string Caption { get; set; }
        public int? Size { get; set; }
        public string Aws { get; set; }
    }
}