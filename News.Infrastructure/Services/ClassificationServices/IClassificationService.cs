using News.Core.Dtos.ClassificationDtos;
using News.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Services.ClassificationServices
{
    public interface IClassificationService
    {
        Task<List<ClassificationViewModel>> GetAll();
        Task<ClassificationViewModel> Get(int id);
        Task<int> Create(CreateClassificationDto dto);
        Task<int> Delete(int id);
        Task<int> Update(UpdateClassificationDto dto);
    }
}
