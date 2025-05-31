using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard
{
    public async Task<BoardResponse> EmptyWith(CreateBoardRequest data)
    {
        var board = new Board(data.Name);

        var newBoard = await BoardsRepository.Create(board);
        return new BoardResponse(1, newBoard.Name);
    }
}