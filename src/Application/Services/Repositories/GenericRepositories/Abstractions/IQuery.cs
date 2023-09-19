namespace Application.Services.Repositories.GenericRepositories.Abstractions;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
