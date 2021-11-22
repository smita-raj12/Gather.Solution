using System.Collections.Generic;

namespace Gather.Models
{
  public class Seeker
  {
    public Seeker()
    {
      this.JoinEntities = new HashSet<JobSeeker>();
    }

    public int SeekerId { get; set; }
    public string Name { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<JobSeeker> JoinEntities { get; set; }
  }
}