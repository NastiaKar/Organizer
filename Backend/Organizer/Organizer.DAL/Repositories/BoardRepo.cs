using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Base;

namespace Organizer.DAL.Repositories;

public class BoardRepo : BaseRepo<Board>
{
    public BoardRepo(DataContext context) : base(context) { }

    internal BoardRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<Board>> GetAllAsync()
    {
        return await Task.Run(() => Table
            .Include(b => b.Assignments));
    }

    public override async Task<Board?> FindAsync(int id)
    {
        return await Table
            .Where(b => b.Id == id)
            .Include(b => b.Assignments)
            .FirstOrDefaultAsync();
    }

    public override async Task<Board?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(b => b.Id == id)
            .Include(b => b.Assignments)
            .FirstOrDefaultAsync();
    }
}