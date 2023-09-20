using Application.Features.Products.Constants;
using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.CategoryId)
            .NotEmpty()
            .WithMessage("category boş olamaz");


        RuleFor(c => c.ProductName)
            .NotEmpty()
            .WithMessage(ProductValidationExceptionMessages.ProductNameCannotBeEmpty)
            .MinimumLength(2)
            .WithMessage(ProductValidationExceptionMessages.ProductNameMinimumLength)
            .MaximumLength(250)
            .WithMessage(ProductValidationExceptionMessages.ProductNameMaximumLength);

    }
}
