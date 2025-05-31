using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application;

public class BoardsRepository : IBoardsRepository
{
    private static readonly List<Board> Boards = [];

    public async Task<Board> Create(Board board)
    {
        Boards.Add(board);
        
        return board;
    }

    public async Task<IEnumerable<Board>> GetAll()
    {
        return Boards;
    }
}