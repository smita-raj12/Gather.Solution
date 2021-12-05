using Microsoft.AspNetCore.Mvc;

namespace Gather.Controllers
{
    public class AboutUsController : Controller
    {

      public ActionResult Index()
      {
        return View();
      }

    }
}