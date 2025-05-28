using FluentAssertions;
using KanbanBoard.Backend.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KanbanBoard.Backend.Tests;

public class IntegrationTests
{
    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var sut = CreateApiClient();

        var response = await sut.GetAsync("user/boards");

        var result = await response.ReadContentAsyncAs<IEnumerable<Board>>();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var sut = CreateApiClient();
        var doc = "test";
        
        var response = await sut.PostAsJsonAsync("user/boards", doc);
        
        var result = await response.ReadContentAsyncAs<Board>();
        result.Name.Should().Be("test");
    }
    
    private static HttpClient CreateApiClient()
    {
        var client = new WebApplicationFactory<Program>().CreateClient();
        client.BaseAddress = new Uri("https://localhost");
        return client;
    }
}

public static class TestHelpers
{
    public static async Task<T> ReadContentAsyncAs<T>(this HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<T>();
    }
}