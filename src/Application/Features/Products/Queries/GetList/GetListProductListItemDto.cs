namespace Application.Features.Products.Queries.GetList;

public sealed class GetListProductListItemDto
{
    public Guid ProductId { get; set; }         
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }
}
