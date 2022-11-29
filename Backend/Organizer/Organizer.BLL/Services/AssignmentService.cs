using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Interfaces;
using Organizer.Models.DTOs.Assignment;

namespace Organizer.BLL.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IMapper _mapper;
    private readonly IAssignmentRepo _repo;

    public AssignmentService(IMapper mapper, IAssignmentRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task<IEnumerable<DisplayAssignmentDTO>> GetAll()
    {
        var assignments = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<DisplayAssignmentDTO>>(assignments);
    }

    public async Task<DisplayAssignmentDTO> GetOne(int id)
    {
        var assignment = await _repo.FindAsync(id);
        if (assignment == null)
            throw new Exception("Entity not found");
        
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task<DisplayAssignmentDTO> Create(CreateAssignmentDTO request)
    {
        var assignment = _mapper.Map<Assignment>(request);
        await _repo.AddAsync(assignment);
        
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task<DisplayAssignmentDTO> Update(UpdateAssignmentDTO request, int id)
    {
        var assignment = await _repo.FindAsync(id);
        if (assignment == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, assignment);
        await _repo.UpdateAsync(assignment!);
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task Delete(int id)
    {
        var assignment = await _repo.FindAsync(id);
        if (assignment == null)
            throw new Exception("Entity not found");

        await _repo.DeleteAsync(assignment!);
    }
}