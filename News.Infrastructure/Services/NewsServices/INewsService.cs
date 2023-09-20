using News.Core.Dtos.NewsDtos;
using News.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Services.NewsServices
{
    public interface INewsService
    {
        Task<List<NewsViewModel>> GetAll();
        Task<NewsViewModel> Get(int id);
        Task<List<NewsViewModel>> GetLast();
        Task<int> Delete(int id);
        Task<int> Create(CreateNewsDto dto);
        Task<int> Update(UpdateNewsDto dto);
        Task<List<NewsViewModel>> Search(string keyword);
    }
}
