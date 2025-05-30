using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.UseCases;

public class GetBoards
{
    public async Task<IEnumerable<Board>> Empty()
    {
        return new List<Board>();
    }
}