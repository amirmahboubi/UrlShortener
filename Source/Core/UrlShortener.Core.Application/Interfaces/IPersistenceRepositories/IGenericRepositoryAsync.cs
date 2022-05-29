namespace UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

public interface IGenericRepositoryAsync<T> where T : class
{
    Task<T?> GetByIdAsync(long id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
}
