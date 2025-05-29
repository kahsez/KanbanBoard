using FluentAssertions;
using KanbanBoard.Backend.Domain;

namespace KanbanBoard.Backend.Tests;

public class IntegrationTests
{
    private const string BoardsUri = "api/boards";

    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var sut = TestHelpers.CreateApiClient();

        var response = await sut.GetAsync(BoardsUri);

        var result = await response.ReadContentAsyncAs<IEnumerable<Board>>();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var doc = "test";
        
        var response = await sut.PostAsJsonAsync(BoardsUri, doc);
        
        var result = await response.ReadContentAsyncAs<Board>();
        result.Name.Should().Be("test");
    }
}