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
    public class JobsController : Controller
    {
        private readonly GatherContext _db;

        private readonly UserManager<ApplicationUser> _userManager;

        public JobsController(UserManager<ApplicationUser> userManager, GatherContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            IQueryable<Job> userJobs = _db.Jobs.OrderBy(name => name.Name);
            if (!string.IsNullOrEmpty(searchString))
            {
                userJobs = userJobs.Where(name => name.Name.Contains(searchString));
            }
            return View(userJobs.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(Job Job, int TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            Job.User = currentUser;
            _db.Jobs.Add (Job);
            _db.SaveChanges();
            if (TreatId != 0)
            {
                _db.TreatJob.Add(new TreatJob(){ TreatId = TreatId, JobId = Job.JobId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var thisJob =_db.Jobs
                    .Include(Job => Job.JoinEntities)
                    .ThenInclude(join => join.Treat)
                    .FirstOrDefault(Job => Job.JobId == id);
            return View(thisJob);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var thisJob = _db.Jobs.FirstOrDefault(Job => Job.JobId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisJob);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Job Job, int TreatId)
        {
            if (TreatId != 0)
            {
                _db.TreatJob.Add(new TreatJob(){ TreatId = TreatId, JobId = Job.JobId });
            }
            _db.Entry(Job).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddTreat(int id)
        {
            var thisJob = _db.Jobs.FirstOrDefault(Job => Job.JobId == id);
            ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
            return View(thisJob);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddTreat(Job Job, int TreatId)
        {
            if (TreatId != 0)
            {
                _db .TreatJob.Add(new TreatJob() { TreatId = TreatId, JobId = Job.JobId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var thisJob = _db.Jobs.FirstOrDefault(Job => Job.JobId == id);
            return View(thisJob);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisJob = _db.Jobs.FirstOrDefault(Job => Job.JobId == id);
            _db.Jobs.Remove (thisJob);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DeleteTreat(int joinId)
        {
            var joinEntry = _db.TreatJob.FirstOrDefault(entry => entry.TreatJobId == joinId);
            _db.TreatJob.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}        