using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News.Core.ViewModels;
using News.Data;
using News.Infrastructure.Services.ClassificationServices;
using News.Infrastructure.Services.NewsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Services.LandingServices
{
    public class LandingService : ILandingService
    {
        private readonly NewsDbContext _context;
        private readonly IClassificationService _classification;
        private readonly INewsService _news;
        private readonly IMapper _mapper;
        public LandingService(NewsDbContext context
            , IClassificationService classification
            , INewsService news
            , IMapper mapper)
        {
            _context = context;
            _classification = classification;
            _news = news;
            _mapper = mapper;
        }
        public async Task<LandingViewModel> Get()
        {
            var lastNews = await _news.GetLast();
            var classifications = await _classification.GetAll();

            var landing = new LandingViewModel()
            {
                Classifications = classifications,
                News = lastNews
            };

            var landingViewModel = _mapper.Map<LandingViewModel>(landing);

            return landingViewModel;
        }
    }
}
