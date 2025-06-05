using KanbanBoard.Backend.Application.DrivenPorts;

namespace KanbanBoard.Backend.Application.UseCases;

public class DeleteBoard(IBoardsRepository boards)
{
    public async Task With(int id)
    {
        await boards.Delete(id);
    }
}