using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core.ViewModels
{
    public class ClassificationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NewsViewModel> News { get; set; }
    }
}
