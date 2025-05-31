using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application;

public class BoardsRepository : IBoardsRepository
{
    private static readonly List<Board> Boards = [];

    public Task<Board> Create(Board board)
    {
        Boards.Add(board);
        
        return Task.FromResult(board);
    }

    public Task<IEnumerable<Board>> GetAll()
    {
        return Task.FromResult<IEnumerable<Board>>(Boards);
    }
}