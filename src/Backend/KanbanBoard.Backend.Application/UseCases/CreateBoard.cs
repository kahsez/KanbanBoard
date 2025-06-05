using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.Dtos;
using KanbanBoard.Backend.Application.Dtos.Mappers;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard(IBoardsRepository boards)
{
    public async Task<BoardResponse> EmptyWith(CreateBoardRequest data)
    {
        var boardModel = data.ToBoardModel();

        var newBoard = await boards.Create(boardModel);
        return newBoard.ToBoardResponse();
    }
}