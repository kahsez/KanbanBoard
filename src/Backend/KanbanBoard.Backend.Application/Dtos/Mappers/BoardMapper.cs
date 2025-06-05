using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.Dtos.Mappers;

internal static class BoardMapper
{
    public static BoardResponse ToBoardResponse(this Board board)
    {
        return new BoardResponse(board.Id, board.Name);
    }
    
    public static Board ToBoardModel(this CreateBoardRequest data)
    {
        return new Board(data.Name);
    }
}