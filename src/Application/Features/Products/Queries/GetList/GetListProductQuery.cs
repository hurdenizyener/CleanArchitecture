using Application.Common.Pagination;
using Application.Common.Pipelines.Caching;
using Application.Common.Pipelines.Logging;
using Application.Common.Requests;
using Application.Common.Responses;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetList;

public sealed class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>, ICachableRequest, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListProductQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

    public bool Bypass { get; }

    public TimeSpan? SlidingExpiration { get; }

    public string? CacheGroupKey => "GetProducts";

    public sealed class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products = await _productRepository.GetListAsync(
                  include: p => p.Include(p => p.Category),
                  index: request.PageRequest.PageIndex,
                  size: request.PageRequest.PageSize,
                  cancellationToken: cancellationToken
                  );

            GetListResponse<GetListProductListItemDto> response = _mapper.Map<GetListResponse<GetListProductListItemDto>>(products);
            return response;
        }
    }
}
