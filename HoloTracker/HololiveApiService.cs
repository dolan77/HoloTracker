using Holodex.NET;
using HoloTracker.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
// using System.Text.Json;

namespace HoloTracker
{
    public class HololiveApiService : IHololiveApiService
    {
        // https://www.youtube.com/watch?v=
        // parameters, you do live?(parameter=)
        // private static readonly HolodexClient client;
        private static readonly HttpClient client;
        // static string? text = File.ReadAllText("D:\\VSProjects\\HoloTracker\\HoloTracker\\ApiKey.txt");
        static HololiveApiService()
        {
        //https://api.holotools.app/
       
            client = new HttpClient() { BaseAddress = new Uri("https://holodex.net/api") };
        }

        /*        public async Task<List<HololiveModel>> GetChannel(string id)
                {
                    throw new NotImplementedException();
                }*/

        // call this to get the Live videos of current members
        public async Task<List<HololiveModel>> GetLive(string org)
        {

            // show only 2 days ahead
            var url = string.Format("/v2/live?org={0}&max_upcoming_hours=48", org);
            var result = new List<HololiveModel>();
            // client.DefaultRequestHeaders
            // try to include the API key in the header of the HTTP request
            var response = await client.GetAsync(url); 
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                result = JsonConvert.DeserializeObject<List<HololiveModel>>(stringResponse);

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