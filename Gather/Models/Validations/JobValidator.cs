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
                                .NotEqual(name => name.Name);
                                
      RuleFor(name=> name.Description).NotNull().WithMessage("required") 
                                      .NotEqual(name => name.Description);
      RuleFor(name=> name.PostDate).NotNull().WithMessage("required").GreaterThanOrEqualTo(r => r.PostDate)
                                    .WithMessage("Date To must be after Date From");   
    }
  }
  
}
