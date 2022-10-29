using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Assignment;

namespace Organizer.BLL.Services;

public class AssignmentService : IAssignmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AssignmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayAssignmentDTO>> GetAll()
    {
        var assignments = await _context.Assignments
            .Include(src => src.Steps)
            .ToListAsync();
        return _mapper.Map<IEnumerable<DisplayAssignmentDTO>>(assignments);
    }

    public async Task<DisplayAssignmentDTO> GetOne(int id)
    {
        var assignment = await _context.Assignments
            .Include(src => src.Steps)
            .FirstOrDefaultAsync(src => src.Id == id);
        if (assignment == null)
            throw new Exception("Entity not found");
        
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task<DisplayAssignmentDTO> Create(CreateAssignmentDTO request)
    {
        var assignment = _mapper.Map<Assignment>(request);
        await _context.AddAsync(assignment);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task<DisplayAssignmentDTO> Update(CreateAssignmentDTO request, int id)
    {
        var assignment = await _context.Assignments.FirstOrDefaultAsync(src => src.Id == id);
        if (assignment == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, assignment);
        _context.Assignments.Update(assignment);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayAssignmentDTO>(assignment);
    }

    public async Task Delete(int id)
    {
        var assignment = await _context.Assignments.FirstOrDefaultAsync(src => src.Id == id);
        if (assignment == null)
            throw new Exception("Entity not found");

        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
    }
}