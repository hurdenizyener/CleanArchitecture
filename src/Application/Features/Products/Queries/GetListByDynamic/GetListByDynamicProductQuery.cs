using Application.Common.Dynamic;
using Application.Common.Pagination;
using Application.Common.Requests;
using Application.Common.Responses;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Products.Queries.GetListByDynamic;

public sealed class GetListByDynamicProductQuery : IRequest<GetListResponse<GetListByDynamicProductListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public sealed class GetListByDynamicProductQueryHandler : IRequestHandler<GetListByDynamicProductQuery, GetListResponse<GetListByDynamicProductListItemDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicProductListItemDto>> Handle(GetListByDynamicProductQuery request, CancellationToken cancellationToken)
        {
            Paginate<Product> products = await _productRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: p => p.Include(p => p.Category),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            GetListResponse<GetListByDynamicProductListItemDto> response = _mapper.Map<GetListResponse<GetListByDynamicProductListItemDto>>(products);
            return response;
        }
    }
}
