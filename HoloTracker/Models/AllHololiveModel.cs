using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HoloTracker.Models
{
    public class AllHololiveModel
    {
        
        public List<HololiveModel>? streamers { get; set; }
        public string? state { get; set; }
    }
}
