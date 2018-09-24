using System;
using System.Linq;
using EasyManager.Domain.Commands;
using EasyManager.Domain.Types;
using FluentValidation;

namespace EasyManager.Domain.Validators
{
    public class ProductValidation<T,R> : AbstractValidator<T> where T : ProductCommand<R>
    {
        protected void ValidateDescription()
        {
            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the product description")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateType()
        {
            RuleFor(p => p)
                .Custom((product, context) => {
                    var fail = false;
                    if(product.ProductType == ProductType.Bundle)
                        if(!product.Bundles.IsNull())
                        {
                            if(!product.Bundles.Any())
                               fail = true;
                        }
                        else
                        {
                            fail = true;
                        }

                        if(fail)
                            context.AddFailure("The product list cannot be empty in a bundle");
                });
        }
    }
}