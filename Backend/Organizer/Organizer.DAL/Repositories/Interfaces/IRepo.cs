using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Entities.Base;

namespace Organizer.DAL.Repositories.Interfaces;

public interface IRepo<T> : IDisposable where T : BaseEntity, new ()
{
    DbSet<T> Table { get; }
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> FindAsync(int id);
    Task<T?> FindAsNoTrackingAsync(int id);
    Task<int> AddAsync(T entity, bool persist = true);
    Task<int> UpdateAsync(T entity, bool persist = true);
    Task<int> DeleteAsync(T entity, bool persist = true);
    Task<int> SaveChangesAsync();
}