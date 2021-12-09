using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gather.Models;

namespace Gather.Controllers
{
  public class SeekersController : Controller
  {
    private readonly GatherContext _db;

    private readonly UserManager<ApplicationUser> _userManager;
    
    public SeekersController( UserManager<ApplicationUser> userManager, GatherContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index(string searchString)
    {
      IQueryable<Seeker> userSeekers = _db.Seekers.OrderBy(name => name.Name);
      if (!string.IsNullOrEmpty(searchString))
      {
        userSeekers = userSeekers.Where(name => name.Name.Contains(searchString));
      }
      return View(userSeekers.ToList());
    }

    [Authorize(Roles = "Seeker")]
    public ActionResult Create()
    {
      ViewBag.JobId = new SelectList(_db.Jobs, "JobId", "Name");
      return View();
    }

    [Authorize(Roles = "Seeker")]
    [HttpPost]
    public async Task<ActionResult> Create(Seeker Seeker, int JobId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Seeker.User = currentUser;
      
      _db.Seekers.Add (Seeker);
      _db.SaveChanges();
      if (JobId != 0)
      {
        _db.JobSeeker.Add(new JobSeeker(){ JobId = JobId, SeekerId = Seeker.SeekerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Job, Seeker")]
    public ActionResult Details(int id)
    {
      var thisSeeker = _db.Seekers
          .Include(Seeker => Seeker.JoinEntities)
          .ThenInclude(join => join.Job)
          .FirstOrDefault(Seeker => Seeker.SeekerId == id);
      return View(thisSeeker);
    }

    [Authorize(Roles = "Seeker, Job")]
    public ActionResult Edit(int id)
    {
      var thisSeeker = _db.Seekers.FirstOrDefault(Seeker => Seeker.SeekerId == id);
      ViewBag.JobId = new SelectList(_db.Jobs, "JobId", "Name");
      return View(thisSeeker);
    }

    [Authorize(Roles = "Seeker,Job")]
    [HttpPost]
    public ActionResult Edit(Seeker Seeker, int JobId)
    {
      if (JobId != 0)
      {
        _db.JobSeeker.Add(new JobSeeker(){ JobId = JobId, SeekerId = Seeker.SeekerId });
      }
      _db.Entry(Seeker).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize(Roles = "Job, Seeker ")]
    public ActionResult Delete(int id)
    {
      var thisSeeker = _db.Seekers.FirstOrDefault(Seeker => Seeker.SeekerId == id);
      return View(thisSeeker);
    }

    [Authorize(Roles = "Job, Seeker")]
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSeeker = _db.Seekers.FirstOrDefault(Seeker => Seeker.SeekerId == id);
      _db.Seekers.Remove(thisSeeker);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
  }
}    