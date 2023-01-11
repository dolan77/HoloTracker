using Holodex.NET;
using HoloTracker.Models;
/*using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;*/
using System.Text.Json;

namespace HoloTracker
{
    public class HololiveApiService : IHololiveApiService
    {
        // https://www.youtube.com/watch?v=
        // parameters, you do live?(parameter=)
        // private static readonly HolodexClient client;
        private static readonly HttpClient client;

        static HololiveApiService()
        {
            client = new HttpClient() { BaseAddress = new Uri("https://api.holotools.app/") };
        }

        /*        public async Task<List<HololiveModel>> GetChannel(string id)
                {
                    throw new NotImplementedException();
                }*/

        // call this to get the Live videos of current members
        public async Task<AllHololiveModel> GetLive()
        {
            // show only 2 hours ahead
            var url = string.Format("/v1/live?hide_channel_desc=1&max_upcoming_hours=48");
            var result = new AllHololiveModel();
            var response = await client.GetAsync(url); 
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                result = JsonSerializer.Deserialize<AllHololiveModel>(stringResponse);

            }

            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}

// , new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase // stuck in an infinite loop at the nested json }