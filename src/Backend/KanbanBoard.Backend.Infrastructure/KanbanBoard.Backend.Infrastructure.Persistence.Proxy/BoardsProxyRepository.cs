using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;
using KanbanBoard.Backend.Infrastructure.Persistence.InMemory;

namespace KanbanBoard.Backend.Infrastructure.Persistence.Proxy;

public class BoardsProxyRepository : IBoardsRepository
{
    private readonly IBoardsRepository repository;

    public BoardsProxyRepository()
    {
        repository = new BoardsInMemoryRepository();
    }
    
    public Task<Board> Create(Board board)
    {
        return repository.Create(board);
    }

    public Task<IEnumerable<Board>> GetAll()
    {
        return repository.GetAll();
    }

    public Task<Board?> GetById(int id)
    {
        return repository.GetById(id);
    }

    public Task<Board> Update(Board board)
    {
        return repository.Update(board);
    }

    public Task<int> Delete(int id)
    {
        return repository.Delete(id);
    }
}