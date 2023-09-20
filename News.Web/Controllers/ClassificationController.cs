using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Infrastructure.Services.ClassificationServices;

namespace News.Web.Controllers
{
    public class ClassificationController : Controller
    {
        private readonly IClassificationService _classification;

        public ClassificationController(IClassificationService classification)
        {
            _classification = classification;
        }

        // GET: ClassificationController
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAllJSON()
        {
            var classifications = await _classification.GetAll();
            return Json(classifications);
        }

        // GET: ClassificationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null || id == 0)
            {
                return Redirect("/Base/NotFound");
            }
            var result = await _classification.Get(id);

            if (result == null )
            {
                return Redirect("/Base/NotFound");
            }
            return View(result);
        }

    }
}
