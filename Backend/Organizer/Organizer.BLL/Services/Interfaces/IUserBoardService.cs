using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Services.Interfaces;

public interface IUserBoardService
{
    Task<IEnumerable<DisplayBoardDTO>> GetAll(int userId);
    Task<DisplayBoardDTO> GetOne(int userId, int id);
    Task<DisplayBoardDTO> Create(int userId, CreateBoardDTO request);
    Task<DisplayBoardDTO> Update(int userId, UpdateBoardDTO request, int id);
    Task Delete(int userId, int id);
}