using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Application.UseCases;

public class GetBoards
{
    public async Task<IEnumerable<BoardResponse>> Empty()
    {
        var boards = await BoardsRepository.GetAll();

        return boards.Select(board => new BoardResponse(1, board.Name)).ToList();
    }
}