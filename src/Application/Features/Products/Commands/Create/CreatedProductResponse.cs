namespace Application.Features.Products.Commands.Create;

public sealed class CreatedProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
}
