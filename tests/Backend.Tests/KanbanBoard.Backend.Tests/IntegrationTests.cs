using FluentAssertions;
using KanbanBoard.Backend.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KanbanBoard.Backend.Tests;

public class IntegrationTests
{
    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var client = CreateApiClient();

        var response = await client.GetAsync("user/boards");

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsAsync<IEnumerable<Board>>();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task PostBoard_ReturnsCreatedBoard()
    {
        var client = CreateApiClient();
        var doc = "test";
        
        var response = await client.PostAsJsonAsync("user/boards", doc);
        
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsAsync<Board>();
        result.Name.Should().Be("test");
    }
    
    private static HttpClient CreateApiClient()
    {
        var client = new WebApplicationFactory<Program>().CreateClient();
        client.BaseAddress = new Uri("https://localhost");
        return client;
    }
}