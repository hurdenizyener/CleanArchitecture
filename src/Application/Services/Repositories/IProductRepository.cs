using Application.Services.Repositories.GenericRepositories.Abstractions;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IProductRepository :IAsyncRepository<Product,Guid>
{
}
