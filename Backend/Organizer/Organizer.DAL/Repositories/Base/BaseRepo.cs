using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities.Base;
using Organizer.DAL.Repositories.Interfaces;

namespace Organizer.DAL.Repositories.Base;

public abstract class BaseRepo<T> : IRepo<T> where T : BaseEntity, new()
{
    protected DataContext Context { get; }
    public DbSet<T> Table { get; }

    public BaseRepo(DataContext context)
    {
        Context = context;
        Table = Context.Set<T>();
    }

    public BaseRepo(DbContextOptions<DataContext> options) : this(new DataContext(options)) { }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await Table.ToListAsync();

    public virtual async Task<T?> FindAsync(int id) => await Table.FindAsync(id);

    public virtual async Task<T?> FindAsNoTrackingAsync(int id)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public virtual async Task<int> AddAsync(T entity, bool persist = true)
    {
        await Table.AddAsync(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> UpdateAsync(T entity, bool persist = true)
    {
        Table.Update(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public virtual async Task<int> DeleteAsync(T entity, bool persist = true)
    {
        Table.Remove(entity);
        return persist ? await SaveChangesAsync() : 0;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}