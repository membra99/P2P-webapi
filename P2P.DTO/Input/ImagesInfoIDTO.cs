using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class ImagesInfoIDTO
    {
        public int ImageId { get; set; }
        public string AltText { get; set; }
        public string Caption { get; set; }
        public string Aws { get; set; }
    }
}