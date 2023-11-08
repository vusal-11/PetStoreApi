using FluentValidation;
using PetsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsData.Services.Validators;

public class ProductTypesValidator : AbstractValidator<ProductType>
{

    public ProductTypesValidator()
    {
        RuleFor(x => x.Name)
           .MaximumLength(30)
           .Matches("^[A-Za-z]+$");
    }


}
