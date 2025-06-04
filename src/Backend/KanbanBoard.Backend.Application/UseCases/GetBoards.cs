using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class GetBoards(IBoardsRepository boards)
{
    public async Task<IEnumerable<BoardResponse>> All()
    {
        var allBoards = await boards.GetAll();

        return allBoards.Select(board => new BoardResponse(board.Id, board.Name)).ToList();
    }

    public async Task<BoardResponse> By(int id)
    {
        var board = await boards.GetById(id);
        return new BoardResponse(board.Id, board.Name);
    }
}