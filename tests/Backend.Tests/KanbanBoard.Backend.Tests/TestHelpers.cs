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
    
    public static async Task<TContentType> GetAndReadResponseContent<TContentType>
        (this HttpClient client, string requestUri)
    {
        var response = await client.GetAsync(requestUri);
        var result = await response.ReadContentAsyncAs<TContentType>();
        return result;
    }
    
    public static async Task<TContentType> PostAndReadResponseContent<TRequestType, TContentType>
        (this HttpClient client, TRequestType request, string requestUri)
    {
        var postResponse = await client.PostAsJsonAsync(requestUri, request);
        var result = await postResponse.ReadContentAsyncAs<TContentType>();
        return result;
    }
}