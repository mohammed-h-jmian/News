using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Core.ViewModels
{
    public class LandingViewModel
    {
        public List<NewsViewModel> News { get; set; }
        public List<ClassificationViewModel> Classifications { get; set; }
    }
}
