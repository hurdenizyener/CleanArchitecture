using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.GetById;

public sealed class GetByIdProductQuery : IRequest<GetByIdProductResponse>
{
    public Guid Id { get; set; }

    public sealed class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdProductResponse response = _mapper.Map<GetByIdProductResponse>(product);
            return response;
        }
    }
}
