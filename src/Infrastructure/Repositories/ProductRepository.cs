using Application.Services.Repositories;
using Application.Services.Repositories.GenericRepositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Repositories;

public sealed class ProductRepository : EfRepositoryBase<Product, Guid, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }
}
