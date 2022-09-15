﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.P2P.MainData
{
    [Table("DataTypes", Schema = "P2P")]
    public class DataType
    {
        public int DataTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DataTypeName { get; set; }

        public ICollection<ReviewAttribute> ReviewAttributes { get; set; }
        public ICollection<UrlTable> UrlTables { get; set; }
        public ICollection<Routes> Routes { get; set; }
        public ICollection<Page> Pages { get; set; }
    }
}