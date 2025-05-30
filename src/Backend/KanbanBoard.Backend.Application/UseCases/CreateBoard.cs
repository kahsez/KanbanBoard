using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Application.UseCases;

public class CreateBoard
{
    public async Task<Board> EmptyWith(string name)
    {
        return new Board(name);
    }
}