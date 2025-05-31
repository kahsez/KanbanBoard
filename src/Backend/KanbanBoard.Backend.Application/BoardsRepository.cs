using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application;

public static class BoardsRepository
{
    private static readonly List<Board> Boards = [];

    public static async Task<Board> Create(Board board)
    {
        Boards.Add(board);
        
        return board;
    }

    public static async Task<IEnumerable<Board>> GetAll()
    {
        return Boards;
    }
}