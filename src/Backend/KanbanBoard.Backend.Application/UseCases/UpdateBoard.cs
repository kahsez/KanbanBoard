using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class UpdateBoard(IBoardsRepository boards)
{
    public async Task<BoardResponse?> With(int id, UpdateBoardRequest data)
    {
        var existingBoard = await boards.GetById(id);
        
        if (existingBoard == null)
            return null;

        existingBoard.Name = data.Name;
        
        return new BoardResponse(id, existingBoard.Name);
    }
}