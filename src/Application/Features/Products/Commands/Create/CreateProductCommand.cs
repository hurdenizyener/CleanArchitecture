using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Create;

public sealed class CreateProductCommand : IRequest<CreatedProductResponse>
{
    public Guid CategoryId { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }

    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            await _productRepository.AddAsync(product);

            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(product);
            return createdProductResponse;

        }
    }
}
