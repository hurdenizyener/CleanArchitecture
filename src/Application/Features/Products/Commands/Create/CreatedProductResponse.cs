namespace Application.Features.Products.Commands.Create;

public sealed class CreatedProductResponse
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
}
