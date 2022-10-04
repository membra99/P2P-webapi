using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P.DTO.Input
{
    public class CategoryIDTO
    {
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public string CategoryName { get; set; }
    }
}