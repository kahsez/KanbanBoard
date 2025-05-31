using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.DrivenPorts;

public interface IBoardsRepository
{
    Task<Board> Create(Board board);

    Task<IEnumerable<Board>> GetAll();
}