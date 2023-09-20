using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.Core.Dtos.NewsDtos;
using News.Data.Models;
using News.Infrastructure.Services.ClassificationServices;
using News.Infrastructure.Services.NewsServices;

namespace News.Web.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _news;
        private readonly IClassificationService _classification;

        public NewsController(INewsService news
            , IClassificationService classification)
        {
            _news = news;
            _classification = classification;
        }
        // GET: NewsController
        public async Task<ActionResult> Index()
        {

            var result = await _news.GetAll();

            return View(result);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public async Task<ActionResult> Create()
        {
            var classifications = await _classification.GetAll();
            var classificationsSelectList = classifications.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.ClassificationsSelectList = classificationsSelectList;
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateNewsDto dto)
        {
            try
            {
                await _news.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var classifications = await _classification.GetAll();
                var classificationsSelectList = classifications.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                ViewBag.ClassificationsSelectList = classificationsSelectList;
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var news = await _news.Get(id);
            if (news == null)
            {
                return Redirect("~/Admin/Base/NotFound");
            }
            
            ViewBag.News = news;
            var classifications = await _classification.GetAll();
            var classificationsSelectList = classifications.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            ViewBag.ClassificationsSelectList = classificationsSelectList;

            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateNewsDto dto)
        {
            try
            {
                await _news.Update(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var news = await _news.Get(dto.Id);
                if (news == null)
                {
                    return Redirect("~/Admin/Base/NotFound");
                }

                ViewBag.News = news;

                var classifications = await _classification.GetAll();
                var classificationsSelectList = classifications.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                ViewBag.ClassificationsSelectList = classificationsSelectList;
                return View();
            }
        }
        [HttpGet]
        // GET: NewsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _news.Delete(id);
            if (result == 0)
            {
                return Redirect("~/Admin/Base/NotFound");
            }
            return Redirect("~/Admin/News/Index");

        }


    }
}
