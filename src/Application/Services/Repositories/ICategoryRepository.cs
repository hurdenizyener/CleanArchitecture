using Application.Services.Repositories.GenericRepositories.Abstractions;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category, Guid>
{
}
