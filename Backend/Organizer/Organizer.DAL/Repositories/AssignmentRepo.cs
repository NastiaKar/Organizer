using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Base;
using Organizer.DAL.Repositories.Interfaces;

namespace Organizer.DAL.Repositories;

public class AssignmentRepo : BaseRepo<Assignment>, IAssignmentRepo
{
    public AssignmentRepo(DataContext context) : base(context) { }

    internal AssignmentRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<Assignment>> GetAllAsync()
    {
        return await Task.Run(() => Table
            .Include(a => a.Steps));
    }

    public override async Task<Assignment?> FindAsync(int id)
    {
        return await Table
            .Where(a => a.Id == id)
            .Include(a => a.Steps)
            .FirstOrDefaultAsync();
    }

    public override async Task<Assignment?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Include(a => a.Steps)
            .FirstOrDefaultAsync();
    }
}