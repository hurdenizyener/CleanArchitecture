namespace Application.Features.Products.Queries.GetById;

public sealed class GetByIdProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }
}
