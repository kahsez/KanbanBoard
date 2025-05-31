using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Infrastructure.Persistence.InMemory;

public class BoardsInMemoryRepository : IBoardsRepository
{
    private readonly List<Board> boards = [];

    public Task<Board> Create(Board board)
    {
        boards.Add(board);
        
        return Task.FromResult(board);
    }

    public Task<IEnumerable<Board>> GetAll()
    {
        return Task.FromResult<IEnumerable<Board>>(boards);
    }
}