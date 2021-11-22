using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gather.Models
{
  public class GatherContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Seeker> Seekers { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobSeeker> JobSeeker { get; set; }

    

    public GatherContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}