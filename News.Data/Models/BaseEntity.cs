using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Data.Models
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDelete = false;
        }
    }
}
