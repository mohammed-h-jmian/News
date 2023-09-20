using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News.Core.Constants;
using News.Core.Dtos.NewsDtos;
using News.Core.ViewModels;
using News.Data;
using News.Infrastructure.Services.FileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Services.NewsServices
{
    public class NewsService : INewsService
    {
        private readonly NewsDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _file;

        public NewsService(NewsDbContext context
            , IMapper mapper
, IFileService file)
        {
            _context = context;
            _mapper = mapper;
            _file = file;
        }

        public async Task<List<NewsViewModel>> GetAll()
        {
            var news = await _context.News
                .Include(x => x.Classification)
                .Where(x => !x.IsDelete)
               .ToListAsync();


            var NewsViewModel = _mapper.Map<List<NewsViewModel>>(news);

            return NewsViewModel;
        }
        public async Task<List<NewsViewModel>> GetLast()
        {
            var news = await _context.News
                .Include(x => x.Classification)
                .Where(x => !x.IsDelete)
                .OrderByDescending(x => x.CreatedAt)
                .Take(10)
                .ToListAsync();



            var NewsViewModel = _mapper.Map<List<NewsViewModel>>(news);

            return NewsViewModel;
        }
        public async Task<NewsViewModel> Get(int id)
        {
            var news =await _context.News
                .Include(x => x.Classification).FirstOrDefaultAsync(x => !x.IsDelete && x.Id == id);

            if (news == null)
            {
                return null;
            }

            var NewsViewModel = _mapper.Map<NewsViewModel>(news);

            return NewsViewModel;
        }
        public async Task<int> Delete(int id)
        {
            var news = await _context.News
     .SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);

            if (news == null)
            {
                return 0;
            }

            news.IsDelete = true;
            await _context.SaveChangesAsync();

            return news.Id;
        }
        public async Task<int> Update(UpdateNewsDto dto)
        {
            var news = await _context.News
     .SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);

            if (news == null)
            {
                return 0;
            }

            if (dto.Image != null)
            {
                news.ImagePath = await _file.SaveFile(dto.Image, "NewsImages");
                news.ImagePath = Paths.baseUrl + Paths.ImageBusPath + news.ImagePath;
            }

            var newsUpdate = _mapper.Map(dto, news);

            _context.News.Update(newsUpdate);
            await _context.SaveChangesAsync();

            return news.Id;
        }
        public async Task<int> Create(CreateNewsDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var news = _mapper.Map<CreateNewsDto, News.Data.Models.News>(dto);

            if (dto.Image != null)
            {
                news.ImagePath = await _file.SaveFile(dto.Image, "NewsImages");
                news.ImagePath = Paths.baseUrl + Paths.ImageBusPath + news.ImagePath;
            }

            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return news.Id;
        }
        public async Task<List<NewsViewModel>> Search(string keyword)
        {
            var searchWords = keyword.ToLower().Split(' ');

            var news = await _context.News
                .Include(x => x.Classification)
                .Where(x => !x.IsDelete)
                .ToListAsync(); // Execute the database query first

            var filteredNews = news
                .Where(x => searchWords.All(word => x.Name.ToLower().Contains(word) || x.Description.ToLower().Contains(word)))
                .OrderByDescending(x => x.CreatedAt)
                .ToList(); // Perform filtering and sorting on the client side

            var newsViewModel = _mapper.Map<List<NewsViewModel>>(filteredNews);

            return newsViewModel;
        }


    }
}
