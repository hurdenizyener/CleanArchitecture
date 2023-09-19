using Application.Common.Pagination;
using Application.Common.Responses;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Application.Features.Products.Queries.GetListByDynamic;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public sealed class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, CreatedProductResponse>().ReverseMap();

        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, UpdatedProductResponse>().ReverseMap();

        CreateMap<Product, DeleteProductCommand>().ReverseMap();
        CreateMap<Product, DeletedProductResponse>().ReverseMap();

        CreateMap<Product, GetByIdProductResponse>().ReverseMap();
        CreateMap<Product, GetListProductListItemDto>()
            .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.CategoryName)) //İsim Farklılıkları Olursa ForMember Kullanılabilir Join İçin 
            .ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();

        CreateMap<Product, GetListByDynamicProductListItemDto>()
            .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.CategoryName))
            .ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListByDynamicProductListItemDto>>().ReverseMap();
    }
}
