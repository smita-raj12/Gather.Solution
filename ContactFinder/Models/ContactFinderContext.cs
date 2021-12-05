using Microsoft.EntityFrameworkCore;

namespace ContactFinder.Models
{
    public class ContactFinderContext : DbContext
    {
        public ContactFinderContext(DbContextOptions<ContactFinderContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>()
                .HasData(
                    new Contact { ContactId = 1, FirstName = "Leena", LastName = "Mammoth", Email = "leena.mammoth@gmail.com", CompanyName = "Intel.com", Location = "US", Department = "HR" },
                    new Contact { ContactId = 2, FirstName = "Jerry", LastName = "Kej", Email = "jerry.kej@gmail.com", CompanyName = "Infosys.com", Location = "IND", Department = "HR" },
                    new Contact { ContactId = 3, FirstName = "Erik", LastName = "Debil", Email = "erik.debil@gmail.com", CompanyName = "Nike.com", Location = "US", Department = "HR"  },
                    new Contact { ContactId = 4, FirstName = "Shiny", LastName = "Lee", Email = "shiny.lee@gmail.com", CompanyName = "Synopys.com", Location = "UK", Department = "HR"  },
                    new Contact { ContactId = 5, FirstName = "Dev", LastName = "Addi", Email = "dev.addi@gmail.com", CompanyName = "Intel.com", Location = "Uk", Department = "HR"  },
                    new Contact { ContactId = 7, FirstName = "Madeline", LastName = "Wigen", Email = "mwigen@jamasoftware.com", CompanyName = "Jamasoftware.com", Location = "US", Department = "HR"  },
                    new Contact { ContactId = 8, FirstName = "Claire", LastName = "Hernandez", Email = "claire.hernandez@puppet.com", CompanyName = "Puppet.com", Location = "US", Department = "HR"  }
                    
                    
                );
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}