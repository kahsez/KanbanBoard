using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Infrastructure.Persistence.InMemory;

public class BoardsInMemoryRepository : IBoardsRepository
{
    private readonly List<Board> boards = [];
    private int nextId = 1;
    
    public Task<Board> Create(Board board)
    {
        board.Id = nextId;
        nextId++;
        
        boards.Add(board);
        
        return Task.FromResult(board);
    }

    public Task<IEnumerable<Board>> GetAll()
    {
        return Task.FromResult<IEnumerable<Board>>(boards);
    }

    public Task<Board?> GetById(int id)
    {
        return Task.FromResult(boards.Find(b => b.Id == id));
    }

    public async Task<Board> Update(Board board)
    {
        var boardToUpdate = await GetById(board.Id);
        if (boardToUpdate == null)
        {
            return await Create(board);
        }
        
        boardToUpdate.Name = board.Name;

        return boardToUpdate;
    }

    public Task<int> Delete(int id)
    {
        return Task.FromResult(boards.RemoveAll(b => b.Id == id));
    }
}