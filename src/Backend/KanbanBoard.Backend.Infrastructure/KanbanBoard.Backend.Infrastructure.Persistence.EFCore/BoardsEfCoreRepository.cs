using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Infrastructure.Persistence.EFCore;

public class BoardsEfCoreRepository : IBoardsRepository
{
    public Task<Board> Create(Board board)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Board>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Board?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Board> Update(Board board)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(int id)
    {
        throw new NotImplementedException();
    }
}