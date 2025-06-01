using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard(IBoardsRepository boards)
{
    public async Task<BoardResponse> EmptyWith(CreateBoardRequest data)
    {
        var board = new Board(data.Name);

        var newBoard = await boards.Create(board);
        return new BoardResponse(newBoard.Id, newBoard.Name);
    }
}