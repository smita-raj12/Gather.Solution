using Microsoft.AspNetCore.Mvc;

namespace Gather.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}