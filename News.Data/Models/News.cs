using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Data.Models
{
    public class News : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClassificationId { get; set; }
        public Classification Classification { get; set; }
        public string ImagePath { get; set; }
    }
}
