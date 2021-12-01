using System.Collections.Generic;
using System;
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

    public string Email { get; set; }

    public int PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }

    public string Education { get; set; }

    public string SkillSet { get; set; }

    public string GitHubLink { get; set; }
    public string LinkedLink { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<JobSeeker> JoinEntities { get; set; }
  }
}