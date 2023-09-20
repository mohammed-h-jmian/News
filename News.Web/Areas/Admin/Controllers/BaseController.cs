using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;

namespace News.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BaseController : Controller
    {
        public ActionResult NotFound()
        {

            return View();
        }
        public ActionResult Unauthorized()
        {

            return View();
        }
    }
}
