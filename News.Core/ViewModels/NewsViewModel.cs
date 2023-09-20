using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClassificationId { get; set; }
        public ClassificationViewModel Classification { get; set; }
        public string ImagePath { get; set; }
        public string CreatedAt { get; set; }
    }
}
