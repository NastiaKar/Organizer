using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Interfaces;
using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Services;

public class BoardService : IBoardService
{
    private readonly IMapper _mapper;
    private readonly IRepo<Board> _repo;

    public BoardService(IMapper mapper, IRepo<Board> repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task<IEnumerable<DisplayBoardDTO>> GetAll()
    {
        var boards = await Task.Run(() => _repo.Table
            .Include(b => b.Assignments));
        return _mapper.Map<IEnumerable<DisplayBoardDTO>>(boards);
    }

    public async Task<DisplayBoardDTO> GetOne(int id)
    {
        var board = await _repo.Table
            .Include(b => b.Assignments)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (board == null)
            throw new Exception("Entity not found");
        
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Create(CreateBoardDTO request)
    {
        var board = _mapper.Map<Board>(request);
        await _repo.AddAsync(board);

        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Update(UpdateBoardDTO request, int id)
    {
        var board = await _repo.FindAsync(id);
        if (board == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, board);
        await _repo.UpdateAsync(board!);
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task Delete(int id)
    {
        var board = await _repo.FindAsync(id);
        if (board == null)
            throw new Exception("Entity not found");

        await _repo.DeleteAsync(board!);
    }
}