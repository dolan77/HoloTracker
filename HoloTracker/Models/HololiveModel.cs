namespace HoloTracker.Models
{
    public class HololiveModel
    {
        public int? id { get; set; }
        public string? yt_video_key { get; set; }
        public string? bb_video_id { get; set; }
        public string? title { get; set; }
        public string? thumbnail { get; set; }
        public string? live_schedule { get; set; }
        public string? live_start { get; set; }
        public string? live_end { get; set; }
        public int? live_viewers { get; set; }
        public ChannelModel? channel { get; set; }
    }
}
