using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Organizer.BLL.Services.Interfaces;
using Organizer.DAL.Data;
using Organizer.DAL.Entities;
using Organizer.DAL.Repositories.Interfaces;
using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Services;

public class UserBoardService : IUserBoardService
{
    private readonly IMapper _mapper;
    private readonly IBoardRepo _repo;

    public UserBoardService(IMapper mapper, IBoardRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task<IEnumerable<DisplayBoardDTO>> GetAll(int userId)
    {
        // var boards = await _repo.GetAllAsync();
        var boards = await Task.Run(() => _repo.Table
            .Include(b => b.User)
            .Where(b => b.UserId == userId)
            .Include(b => b.Assignments));
        return _mapper.Map<IEnumerable<DisplayBoardDTO>>(boards);
    }

    public async Task<DisplayBoardDTO> GetOne(int userId, int id)
    {
        // var board = await _repo.FindAsync(id);
        var board = await Task.Run(() => _repo.Table
            .Include(b => b.User)
            .Where(b => b.UserId == userId)
            .Include(b => b.Assignments)
            .FirstOrDefaultAsync());
        if (board == null)
            throw new Exception("Entity not found");
        
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Create(int userId, CreateBoardDTO request)
    {
        var board = _mapper.Map<Board>(request);
        board.UserId = userId;
        await _repo.AddAsync(board);

        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task<DisplayBoardDTO> Update(int userId, UpdateBoardDTO request, int id)
    {
        var board = await _repo.FindAsync(id);
        if (board == null)
            throw new Exception("Entity not found");

        _mapper.Map(request, board);
        await _repo.UpdateAsync(board!);
        return _mapper.Map<DisplayBoardDTO>(board);
    }

    public async Task Delete(int userId, int id)
    {
        var board = await _repo.FindAsync(id);
        if (board == null)
            throw new Exception("Entity not found");

        await _repo.DeleteAsync(board!);
    }
}