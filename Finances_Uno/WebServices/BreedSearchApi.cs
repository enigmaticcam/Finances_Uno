using System.Net;
using System.Text.Json;
using Finances_Uno.Models.DataModels;

namespace Finances_Uno.WebServices;

public class BreedSearchApi : WebApiBase
{
    public async Task<IEnumerable<Breed>> Search(string search)
    {
        var result = await this.GetAsync(
            $"https://api.thecatapi.com/v1/breeds/search?q={WebUtility.HtmlEncode(search)}",
            new Dictionary<string, string> {
                    {"accept", "application/json" },
                    {"x-api-key", "live_XzhKx1tCwROAmJWyoLM3FhFATFgp9mwNi0ESH9uT2R4orWiPX6PRVLXlbszIuTqA"}
            });

        if (result != null)
        {
            return JsonSerializer.Deserialize<IEnumerable<Breed>>(result);
        }

        return new List<Breed>();
    }
}
