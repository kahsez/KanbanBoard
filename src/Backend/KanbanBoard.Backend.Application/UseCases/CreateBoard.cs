using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard
{
    public async Task<BoardResponse> EmptyWith(CreateBoardRequest data)
    {
        return new BoardResponse(1, data.Name);
    }
}