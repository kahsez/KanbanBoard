using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class GetBoards
{
    public async Task<IEnumerable<BoardResponse>> Empty()
    {
        return new List<BoardResponse>();
    }
}