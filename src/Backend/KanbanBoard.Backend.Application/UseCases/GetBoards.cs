using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Application.Dtos.Mappers;

namespace KanbanBoard.Backend.Application.UseCases;

public class GetBoards(IBoardsRepository boards)
{
    public async Task<IEnumerable<BoardResponse>> All()
    {
        var allBoards = await boards.GetAll();

        return allBoards.Select(board => board.ToBoardResponse()).ToList();
    }

    public async Task<BoardResponse?> By(int id)
    {
        var board = await boards.GetById(id);
        return board?.ToBoardResponse();
    }
}