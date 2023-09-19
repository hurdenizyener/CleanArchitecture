namespace Application.Features.Products.Commands.Update
{
    public sealed class UpdatedProductResponse
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
    }
}
