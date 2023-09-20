using AutoMapper;
using Microsoft.EntityFrameworkCore;
using News.Core.Constants;
using News.Core.Dtos.ClassificationDtos;
using News.Core.Dtos.NewsDtos;
using News.Core.ViewModels;
using News.Data;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Services.ClassificationServices
{
    public class ClassificationService : IClassificationService
    {
        private readonly NewsDbContext _context;
        private readonly IMapper _mapper;
        public ClassificationService(NewsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ClassificationViewModel>> GetAll()
        {
            var classifications = await _context.Classifications
                .Where(x => !x.IsDelete)
                .Include(x => x.News)
               .ToListAsync();

            var classificationsViewModel = _mapper.Map<List<ClassificationViewModel>>(classifications);

            return classificationsViewModel;
        }

        public async Task<ClassificationViewModel> Get(int id)
        {
            var classification = await _context.Classifications
                .Include(x => x.News)
                .FirstOrDefaultAsync(x => !x.IsDelete && x.Id == id);

            if (classification == null)
            {
                return null;
            }

            // Order the News by their CreatedAt property in descending order
            classification.News = classification.News.OrderByDescending(n => n.CreatedAt).ToList();

            var classificationViewModel = _mapper.Map<ClassificationViewModel>(classification);

            return classificationViewModel;
        }


        public async Task<int> Delete(int id)
        {
            var classification = await _context.Classifications
     .SingleOrDefaultAsync(x => x.Id == id && !x.IsDelete);

            if (classification == null)
            {
                return 0;
            }

            classification.IsDelete = true;
            await _context.SaveChangesAsync();

            foreach (var news in await _context.News
     .Where(x => x.ClassificationId == id && !x.IsDelete).ToListAsync())
            {
                news.IsDelete = true;
            }
            await _context.SaveChangesAsync();

            return classification.Id;
        }
        public async Task<int> Create(CreateClassificationDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var classification = _mapper.Map<CreateClassificationDto, News.Data.Models.Classification>(dto);


            await _context.Classifications.AddAsync(classification);
            await _context.SaveChangesAsync();
            return classification.Id;
        }
        public async Task<int> Update(UpdateClassificationDto dto)
        {
            var classification = await _context.Classifications
     .SingleOrDefaultAsync(x => x.Id == dto.Id && !x.IsDelete);

            if (classification == null)
            {
                return 0;
            }

            var classificationUpdate = _mapper.Map(dto, classification);

            _context.Classifications.Update(classificationUpdate);
            await _context.SaveChangesAsync();

            return classification.Id;
        }

    }
}
