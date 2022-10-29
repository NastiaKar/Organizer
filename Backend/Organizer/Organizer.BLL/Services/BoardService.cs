using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Services;

public class BoardService : IBoardService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public BoardService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DisplayBoardDTO>> GetAll()
    {
        var boards = await _context.Boards
            .Include(src => src.Assignments)
            .ToListAsync();
        return _mapper.Map<IEnumerable<DisplayBoardDTO>>(boards);
    }

    public async Task<DisplayBoardDTO> GetOne(int id)
    {
        var board = await _context.Boards
            .Include(src => src.Assignments)
            .FirstOrDefaultAsync(src => src.Id == id);
        if (board == null)
            throw new Exception("Entity not found");

        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Create(CreateBoardDTO request)
    {
        var board = _mapper.Map<Board>(request);
        await _context.AddAsync(board);

        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Update(UpdateBoardDTO request, int id)
    {
        var board = await _context.Boards.FirstOrDefaultAsync(src => src.Id == id);
        if (board == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, board);
        _context.Boards.Update(board);
        await _context.SaveChangesAsync();
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task Delete(int id)
    {
        var board = await _context.Boards.FirstOrDefaultAsync(src => src.Id == id);
        if (board == null)
            throw new Exception("Entity not found");

        _context.Boards.Remove(board);
        await _context.SaveChangesAsync();
    }
}