using Application.Services.Repositories;
using Application.Services.Repositories.GenericRepositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Repositories;

public sealed class CategoryRepository : EfRepositoryBase<Category, Guid, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}