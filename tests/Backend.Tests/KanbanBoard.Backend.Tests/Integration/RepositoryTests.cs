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

    [Test]
    public async Task UpdateNonExistingBoard_CreatesNewBoard()
    {
        IBoardsRepository sut = new BoardsInMemoryRepository();
        
        await sut.Update(new Board("test"));

        var boards = await sut.GetAll();
        boards.Should().HaveCount(1).And.Contain(board => board.Name == "test");
    }

    [Test]
    public async Task UpdateWorksWithoutAliasing()
    {
        IBoardsRepository sut = new BoardsInMemoryRepository();
        var original = await sut.Create(new Board("original"));
        var copy = new Board("copy")
        {
            Id = original.Id
        };

        await sut.Update(copy);
        
        var boards = await sut.GetAll();
        boards.Should().HaveCount(1).And.Contain(board => board.Name == "copy");
    }
}