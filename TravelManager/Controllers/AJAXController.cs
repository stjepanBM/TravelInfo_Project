using System.Web.Mvc;
using TravelManager.Dal;

namespace TravelManager.Controllers
{
    public class AJAXController : Controller
    {
        public static IRepository Repo = RepoFactory.GetRepository();
        // GET: AJAX
        public ActionResult GetDrivers()
        {
            return Json(Repo.GetDrivers(), JsonRequestBehavior.AllowGet);
        }
    }
}