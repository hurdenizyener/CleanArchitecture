namespace Application.Features.Products.Queries.GetListByDynamic;

public sealed class GetListByDynamicProductListItemDto
{
    public Guid ProductId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }
}
