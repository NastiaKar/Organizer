using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Step;

namespace Organizer.BLL.Services;

public class StepService : IStepService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StepService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayStepDTO>> GetAll()
    {
        var steps = await _context.Steps.ToListAsync();

        return _mapper.Map<IEnumerable<DisplayStepDTO>>(steps);
    }

    public async Task<DisplayStepDTO> GetOne(int id)
    {
        var step = await _context.Steps.FirstOrDefaultAsync(src => src.Id == id);
        if (step == null)
            throw new Exception("Entity not found");

        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task<DisplayStepDTO> Create(CreateStepDTO request)
    {
        var step = _mapper.Map<Step>(request);
        await _context.AddAsync(step);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task<DisplayStepDTO> Update(UpdateStepDTO request, int id)
    {
        var step = await _context.Steps.FirstOrDefaultAsync(src => src.Id == id);
        if (step == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, step);
        _context.Steps.Update(step);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task Delete(int id)
    {
        var step = await _context.Steps.FirstOrDefaultAsync(src => src.Id == id);
        if (step == null)
            throw new Exception("Entity not found");

        _context.Steps.Remove(step);
        await _context.SaveChangesAsync();
    }
}