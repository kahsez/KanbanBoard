using KanbanBoard.Backend.Application.DrivenPorts;

namespace KanbanBoard.Backend.Application.UseCases;

public class DeleteBoard(IBoardsRepository boards)
{
    public async Task<int> With(int id)
    {
        return await boards.Delete(id);
    }
}