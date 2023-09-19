using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public sealed class UpdateProductCommand : IRequest<UpdatedProductResponse>
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }

    public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);

            product = _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product);
            UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

            return response; ;
        }
    }

}
