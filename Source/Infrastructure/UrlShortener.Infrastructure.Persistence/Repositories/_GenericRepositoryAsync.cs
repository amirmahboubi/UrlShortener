using Microsoft.EntityFrameworkCore;
using UrlShortener.Core.Application.Interfaces.IPersistenceRepositories;

namespace UrlShortener.Infrastructure.Persistence.Repositories;

internal class _GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly DbContext _dbContext;

    public _GenericRepositoryAsync(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> GetByIdAsync(long id) =>
            await _dbContext.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
