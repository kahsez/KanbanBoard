using FluentAssertions;
using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Tests;

public class IntegrationTests
{
    private const string BoardsUri = "api/boards";

    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var sut = TestHelpers.CreateApiClient();

        var response = await sut.GetAsync(BoardsUri);

        var result = await response.ReadContentAsyncAs<IEnumerable<BoardResponse>>();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var doc = new CreateBoardRequest("test");
        
        var response = await sut.PostAsJsonAsync(BoardsUri, doc);
        
        var result = await response.ReadContentAsyncAs<BoardResponse>();
        result.Name.Should().Be("test");
    }
}