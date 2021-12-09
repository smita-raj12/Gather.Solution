using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public string Description { get; set; }
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime PostDate { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<JobSeeker> JoinEntities { get;}
  }
}