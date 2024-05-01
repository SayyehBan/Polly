using System.Text.Json;

namespace ClientApi.Models.Services;
public interface IApiService
{
    Task<ValuesDto> GetValues();
}

public class RApiService : IApiService
{
    private readonly HttpClient httpClient;

    public RApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<ValuesDto> GetValues()
    {
        var response = await httpClient.GetAsync("/api/values");

        var mydata = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        var data = JsonSerializer.Deserialize<List<string>>(mydata);
        return new ValuesDto
        {
            Values = data
        };

    }
}

public class ValuesDto
{
    public List<string>? Values { get; set; }
}