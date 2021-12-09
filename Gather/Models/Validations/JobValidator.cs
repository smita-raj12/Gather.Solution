using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gather.Models;
using FluentValidation;

namespace Gather.MVC.Validator
{
  public class JobValidator:AbstractValidator<Job>
  {
    public JobValidator()
    {
      
      RuleFor(name => name.Name).NotNull().WithMessage("required")
                                .Length(5, 100);

      RuleFor(name=> name.Description).NotEmpty().WithMessage("required")
                                      .Matches("^[a-z A-Z 0-9]*$").WithMessage("Special Charters not allowed")
                                      .Length(5, 400);
                                      
      RuleFor(name=> name.PostDate).NotNull().WithMessage("required");
      RuleFor(name=> name.PostDate).Must(Validate_Date)
                                  .WithMessage("Date To must be after today's date");   
    }
    private bool Validate_Date(DateTime date)  
    {  
        DateTime Current = DateTime.Today;  
        if ( date>= Current)  
        {  
            return true;  
        }  
        else  
        {  
          return false;  
        }  
    }  
  }
  
}
