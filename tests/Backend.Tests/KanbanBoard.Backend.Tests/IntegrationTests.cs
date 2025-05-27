using FluentAssertions;
using KanbanBoard.Backend.Domain;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KanbanBoard.Backend.Tests;

public class IntegrationTests
{
    [Test]
    public async Task BoardsListIsEmptyByDefault()
    {
        var client = new WebApplicationFactory<Program>().CreateClient();
        client.BaseAddress = new Uri("https://localhost");

        var response = await client.GetAsync("user/boards");

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsAsync<IEnumerable<Board>>();
        result.Should().BeEmpty();
    }
}