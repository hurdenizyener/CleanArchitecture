using Application.Common.Dynamic;
using Application.Common.Requests;
using Application.Common.Responses;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using Application.Features.Products.Queries.GetListByDynamic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ProductsController : BaseController
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
    {
        CreatedProductResponse response = await Mediator.Send(createProductCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
    {
        UpdatedProductResponse response = await Mediator.Send(updateProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedProductResponse response = await Mediator.Send(new DeleteProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdProductQuery getByIdProductQuery = new() { Id = id };
        GetByIdProductResponse response = await Mediator.Send(getByIdProductQuery);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery getListProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductListItemDto> response = await Mediator.Send(getListProductQuery);
        return Ok(response);
    }

    [HttpPost("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        GetListByDynamicProductQuery getListByDynamicProductQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicProductListItemDto> response = await Mediator.Send(getListByDynamicProductQuery);
        return Ok(response);
    }
}
