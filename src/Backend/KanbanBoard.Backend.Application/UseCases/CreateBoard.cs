using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard
{
    public async Task<BoardResponse> EmptyWith(CreateBoardRequest data)
    {
        return new BoardResponse(1, data.Name);
    }
}