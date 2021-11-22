using System.Collections.Generic;

namespace Gather.Models
{
  public class Job
  {
    public Job()
    {
      this.JoinEntities = new HashSet<JobSeeker>();
    }

    public int JobId { get; set; }
    public string Name { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<JobSeeker> JoinEntities { get;}
  }
}