using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;
using the_squad_server.Models;

namespace the_squad_server.API;
public class APIService<Tcrt> : IDisposable where Tcrt : class
{
    private readonly HttpClient _httpClient;
    private readonly string _key;
    public APIService(HttpClient httpClient, string key, string userId)
    {
        _key = key;
        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri("https://squad-apis.azurewebsites.net");

        _httpClient.DefaultRequestHeaders.Add(
            HeaderNames.Accept, "application/json");
        _httpClient.DefaultRequestHeaders.Add(
            HeaderNames.UserAgent, "the-squad-web");
    }

    public async Task PostServerActionAsync(Server server)
    {
        var url = string.Format("/api/vm?code={0}", _key);
        var data = JsonSerializer.Serialize(server);
        var content = new StringContent(data,
                                        Encoding.UTF8,
                                        MediaTypeNames.Application.Json);
        await _httpClient.PostAsync(url, content).ConfigureAwait(false);
    }
    public async Task GetServerStatusAsync(Server server)
    {
        await _httpClient.GetFromJsonAsync<Server>(string.Format("/api/vm?code={0}&id={1}", _key,server.Id));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing) 
        {
        }
    }
}