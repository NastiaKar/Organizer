using Organizer.Models.DTOs.Board;

namespace Organizer.BLL.Services.Interfaces;

public interface IBoardService
{
    Task<IEnumerable<DisplayBoardDTO>> GetAll();
    Task<DisplayBoardDTO> GetOne(int id);
    Task<DisplayBoardDTO> Create(CreateBoardDTO request);
    Task<DisplayBoardDTO> Update(UpdateBoardDTO request, int id);
    Task Delete(int id);
}