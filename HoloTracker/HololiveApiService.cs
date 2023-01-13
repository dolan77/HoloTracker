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

        private static readonly HttpClient client;
        static HololiveApiService()
        {
        //https://api.holotools.app/
       
            client = new HttpClient() { BaseAddress = new Uri("https://holodex.net/api") };
        }

        // call this to get the Live videos of current members
        public async Task<List<HololiveModel>> GetLive(string org)
        {

            // show only 2 days ahead for the api live call
            var url = string.Format("/v2/live?org={0}&max_upcoming_hours=48", org);
            var result = new List<HololiveModel>();

            // try to include the API key in the header of the HTTP request, so far ive been not using the api key
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