namespace UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
}
