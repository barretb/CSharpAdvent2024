namespace CSharpAdvent2024.Web;

public class NaughtyNiceApiClient(HttpClient httpClient)
{
    public async Task<string[]> GetNaughtyListAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<string>? naughtyList = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<string>("/getnaughtylist", cancellationToken))
        {
            if (naughtyList?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                naughtyList ??= [];
                naughtyList.Add(forecast);
            }
        }

        return naughtyList?.ToArray() ?? [];
    }
    public async Task<string[]> GetNiceListAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<string>? niceList = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<string>("/getnicelist", cancellationToken))
        {
            if (niceList?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                niceList ??= [];
                niceList.Add(forecast);
            }
        }

        return niceList?.ToArray() ?? [];
    }
}
