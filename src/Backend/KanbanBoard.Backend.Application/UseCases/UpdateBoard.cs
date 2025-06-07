using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class UpdateBoard
{
    public Task<BoardResponse> With(int id, UpdateBoardRequest data)
    {
        return Task.FromResult(new BoardResponse(id, data.Name));
    }
}