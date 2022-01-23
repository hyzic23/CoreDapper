using System.Linq;
using coredapperapi.Model;
using FluentValidation;

namespace coredapperapi.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Please Name is required")
            .Length(2,25).Must(IsValidName).WithMessage("{PropertyName} should be all letters");

            RuleFor(x => x.Price)
            .NotNull()
            .WithMessage("Please Price is required");

            RuleFor(x => x.Quantity).NotNull().WithMessage("Please Quantity is required");


        }



        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }


    }




    

}