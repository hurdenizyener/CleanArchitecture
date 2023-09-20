using Application.Common.Exceptions.Types;
using Application.Common.Rules;
using Application.Features.Products.Constants;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.Products.Rules;

public sealed class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductNameCannotBeDublicatedWhenInserted(string productName)
    {
        Product? result = await _productRepository.GetAsync(predicate: p => p.ProductName.ToLower() == productName.ToLower());

        if (result != null)
        {
            throw new BusinessException(ProductMessages.ProductNameExists);

        }
    }
}
