using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Interfaces;
using Organizer.Models.DTOs.Step;
using Organizer.Models.Exceptions;

namespace Organizer.BLL.Services;

public class StepService : IStepService
{
    private readonly IStepRepo _repo;
    private readonly IMapper _mapper;

    public StepService(IStepRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayStepDTO>> GetAll()
    {
        var steps = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DisplayStepDTO>>(steps);
    }

    public async Task<DisplayStepDTO> GetOne(int id)
    {
        var step = await _repo.FindAsync(id);
        if (step == null)
            throw new StepNotFoundException(nameof(step), "Step not found");

        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task<DisplayStepDTO> Create(CreateStepDTO request)
    {
        var step = _mapper.Map<Step>(request);
        await _repo.AddAsync(step);
        
        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task<DisplayStepDTO> Update(UpdateStepDTO request, int id)
    {
        var step = await _repo.FindAsync(id);
        if (step == null)
            throw new StepNotFoundException(nameof(step), "Step not found");

        _mapper.Map(request, step);
        await _repo.UpdateAsync(step!);
        return _mapper.Map<DisplayStepDTO>(step);
    }

    public async Task Delete(int id)
    {
        var step = await _repo.FindAsync(id);
        if (step == null)
            throw new StepNotFoundException(nameof(step), "Step not found");

        await _repo.DeleteAsync(step);
    }
}