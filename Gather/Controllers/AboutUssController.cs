using Microsoft.AspNetCore.Mvc;

namespace Gather.Controllers
{
    public class AboutUssController : Controller
    {
      
      // [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}