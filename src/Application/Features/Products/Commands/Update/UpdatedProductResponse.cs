namespace Application.Features.Products.Commands.Update
{
    public sealed class UpdatedProductResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
