using Microsoft.AspNetCore.Mvc.Testing;

namespace KanbanBoard.Backend.Tests;

public static class TestHelpers
{
    public static HttpClient CreateApiClient()
    {
        var client = new WebApplicationFactory<Program>().CreateClient();
        client.BaseAddress = new Uri("https://localhost");
        return client;
    }
    
    public static async Task<T> ReadContentAsyncAs<T>(this HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<T>();
    }
}