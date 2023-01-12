namespace HoloTracker.Models
{
    public class HololiveModel
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? type { get; set; }
        public string? topic_id { get; set; }
        public string? published_at { get; set; }
        public string? available_at { get; set; }
        public int? duration { get; set; }
        public string? status { get; set; }
        public string? start_schedule { get; set; }
        public int? live_viewers { get; set; }
        public ChannelModel? channel { get; set; }
    }
}
