using System.Net;
using FluentAssertions;
using KanbanBoard.Backend.Application.Dtos;

namespace KanbanBoard.Backend.Tests.Integration;

public class BoardsTests
{
    private const string BoardsUri = "api/Boards";

    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var sut = TestHelpers.CreateApiClient();

        var result = await sut.GetAndReadResponseContent<IEnumerable<BoardResponse>>(BoardsUri);
        
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var doc = new CreateBoardRequest("test");
        
        var postResponse = await sut.PostAsJsonAsync(BoardsUri, doc);
        var result = await postResponse.ReadContentAsyncAs<BoardResponse>();

        postResponse.Headers.Location.Should().NotBeNull();
        postResponse.Headers.Location.LocalPath.Should().Be($"/{BoardsUri}/{result.Id}");
        result.Name.Should().Be("test");
    }

    [Test]
    public async Task GetBoards_AfterPostBoard_ReturnsExistingBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var createBoardRequest = new CreateBoardRequest("test");
        var existingBoard = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(createBoardRequest, BoardsUri);
        
        var result = await sut.GetAndReadResponseContent<IEnumerable<BoardResponse>>(BoardsUri);
 
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
    
    [Test]
    public async Task GetBoardById_WhenBoardExists_ReturnsBoardWithCorrectId()
    {
        var sut = TestHelpers.CreateApiClient();
        var anyBoard = new CreateBoardRequest("test");
        var firstPost = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(anyBoard, BoardsUri);
        var secondPost = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(anyBoard, BoardsUri);

        var firstGet = await sut.GetAndReadResponseContent<BoardResponse>($"{BoardsUri}/{firstPost.Id}");
        var secondGet = await sut.GetAndReadResponseContent<BoardResponse>($"{BoardsUri}/{secondPost.Id}");

        firstGet.Id.Should().Be(firstPost.Id);
        secondGet.Id.Should().Be(secondPost.Id);
    }
    
    [Test]
    public async Task GetBoardById_WhenBoardDoesNotExist_ReturnsNotFound()
    {
        var sut = TestHelpers.CreateApiClient();

        const int nonExistingId = 99999;
        var response = await sut.GetAsync($"{BoardsUri}/{nonExistingId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Delete_WhenBoardExists_RemovesBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var anyBoard = new CreateBoardRequest("test");
        var doc = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(anyBoard, BoardsUri);

        var response = await sut.DeleteAsync($"{BoardsUri}/{doc.Id}");

        var boards = await sut.GetAndReadResponseContent<IEnumerable<BoardResponse>>(BoardsUri);
        response.EnsureSuccessStatusCode();
        boards.Should().BeEmpty();
    }
    
    [Test]
    public async Task Delete_WhenBoardDoesNotExist_ReturnsNotFound()
    {
        var sut = TestHelpers.CreateApiClient();

        const int nonExistingId = 99999;
        var response = await sut.DeleteAsync($"{BoardsUri}/{nonExistingId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Test]
    public async Task PutBoard_WhenBoardDoesNotExist_ReturnsNotFound()
    {
        var sut = TestHelpers.CreateApiClient();
        
        const int nonExistingId = 99999;
        var response = await sut.PutAsJsonAsync($"{BoardsUri}/{nonExistingId}", new {Name = "newName"});
        
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Test]
    public async Task PutBoard_WhenBoardExists_ReturnsUpdatedBoard()
    {
        var sut = TestHelpers.CreateApiClient();
        var anyBoard = new CreateBoardRequest("oldName");
        var postedBoard = await sut.PostAndReadResponseContent<CreateBoardRequest, BoardResponse>(anyBoard, BoardsUri);

        var updateBoardRequest = new UpdateBoardRequest("newName");
        var response = await sut.PutAsJsonAsync($"{BoardsUri}/{postedBoard.Id}", updateBoardRequest);
        
        response.EnsureSuccessStatusCode();
        var updatedBoard = await response.ReadContentAsyncAs<BoardResponse>();
        updatedBoard.Id.Should().Be(postedBoard.Id);
        updatedBoard.Name.Should().Be("newName");
    }
}