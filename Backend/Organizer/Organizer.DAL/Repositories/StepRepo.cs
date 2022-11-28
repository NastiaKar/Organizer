using Microsoft.EntityFrameworkCore;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Base;

namespace Organizer.DAL.Repositories;

public class StepRepo : BaseRepo<Step>
{
    public StepRepo(DataContext context) : base(context) { }

    internal StepRepo(DbContextOptions<DataContext> options) : base(options) { }

    public override async Task<IEnumerable<Step>> GetAllAsync()
    {
        return await Task.Run(() => Table.ToList());
    }

    public override async Task<Step?> FindAsync(int id)
    {
        return await Table.Where(s => s.Id == id).FirstOrDefaultAsync();
    }

    public override async Task<Step?> FindAsNoTrackingAsync(int id)
    {
        return await Table.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}