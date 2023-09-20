using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Core.Dtos.ClassificationDtos;
using News.Data.Models;
using News.Infrastructure.Services.ClassificationServices;

namespace News.Web.Areas.Admin.Controllers
{
    public class ClassificationController : BaseController
    {
        private readonly IClassificationService _classification;

        public ClassificationController(IClassificationService classification)
        {
            _classification = classification;
        }
            // GET: ClassificationController
        public async Task<ActionResult> Index()
        {
            var result = await _classification.GetAll();

            return View(result);
        }

        // GET: ClassificationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var classification = await _classification.Get(id);
            return View(classification);
        }

        // GET: ClassificationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateClassificationDto dto)
        {
            try
            {
                await _classification.Create(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: ClassificationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var classification = await _classification.Get(id);
            if (classification == null)
            {
                return Redirect("~/Admin/Base/NotFound");
            }

            ViewBag.Classification = classification;
            return View();
        }

        // POST: ClassificationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateClassificationDto dto)
        {
            try
            {
                await _classification.Update(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var classification = await _classification.Get(dto.Id);
                if (classification == null)
                {
                    return Redirect("~/Admin/Base/NotFound");
                }

                ViewBag.Classification = classification;
                return View();
            }
        }
        [HttpGet]
        // GET: ClassificationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _classification.Delete(id);
            if (result == 0)
            {
                return Redirect("~/Admin/Base/NotFound");
            }
            return Redirect("~/Admin/Classification/Index");
        }


    }
}
