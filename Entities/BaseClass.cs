using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BaseClass
    {
        public int LogUserId { get; set; }
        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        public bool IsActive { get; set; }
    }
}
