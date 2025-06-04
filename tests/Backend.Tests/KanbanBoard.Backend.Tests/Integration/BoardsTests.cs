using FluentAssertions;
using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Tests.Integration;

public class BoardsTests
{
    private const string BoardsUri = "api/boards";

    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var sut = TestHelpers.CreateApiClient();

        var result = await sut.GetAndReadResponseContent<BoardResponse>(BoardsUri);
        
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var doc = new CreateBoardRequest("test");
        
        var result = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(doc, BoardsUri);

        result.Name.Should().Be("test");
    }

    [Test]
    public async Task GetBoards_AfterPostBoard_ReturnsExistingBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var createBoardRequest = new CreateBoardRequest("test");
        var existingBoard = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(createBoardRequest, BoardsUri);
        
        var result = await sut.GetAndReadResponseContent<BoardResponse>(BoardsUri);
 
        result.Should().HaveCount(1).And.Contain(board => board.Name == existingBoard.Name);
    }

    [Test]
    public async Task PostTwoTimes_ReturnsBoardsWithDifferentIDs()
    {
        var sut = TestHelpers.CreateApiClient();
        var doc = new CreateBoardRequest("test");
        
        var firstBoard = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(doc, BoardsUri);
        var secondBoard = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(doc, BoardsUri);

        firstBoard.Id.Should().NotBe(secondBoard.Id);
    }
}