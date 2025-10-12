namespace Finances_Uno.WebServices;
public abstract class WebApiBase
{
    protected static HttpClient _client;

    static WebApiBase()
    {
        _client = new HttpClient();
    }

    private HttpRequestMessage CreateRequestMessage(HttpMethod method, string url, Dictionary<string, string> headers = null)
    {
        var httpRequestMessage = new HttpRequestMessage(method, url);
        if (headers != null && headers.Any())
        {
            foreach (var header in headers)
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
        }

        return httpRequestMessage;
    }

    protected async Task<string> GetAsync(string url, Dictionary<string, string> headers = null)
    {
        using (var request = CreateRequestMessage(HttpMethod.Get, url, headers))
        using (var response = await _client.SendAsync(request))
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }

    // Insert DeleteAsync method below here

    // Insert PostAsync method below here

    // Insert PutAsync method below here
}
