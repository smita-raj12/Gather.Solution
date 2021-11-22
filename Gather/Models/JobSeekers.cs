namespace Gather.Models
{
  public class JobSeeker
  {       
    public int JobSeekerId { get; set; }
    public int JobId { get; set; }
    public int SeekerId { get; set; }
    public virtual Job Job { get; set; }
    public virtual Seeker Seeker { get; set; }
  }
}