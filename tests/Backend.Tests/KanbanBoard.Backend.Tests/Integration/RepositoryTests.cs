using FluentAssertions;
using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Domain;
using KanbanBoard.Backend.Infrastructure.Persistence.InMemory;

namespace KanbanBoard.Backend.Tests.Integration;

public class RepositoryTests
{
    [Test]
    public async Task RepositoryDoesNotUseDefaultAsIdForEntities()
    {
        IBoardsRepository sut = new BoardsInMemoryRepository();
        
        var createdBoard = await sut.Create(new Board("test"));
        
        createdBoard.Id.Should().NotBe(default);
    }
}