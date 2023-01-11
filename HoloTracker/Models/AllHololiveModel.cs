namespace HoloTracker.Models
{
    public class AllHololiveModel
    {
        public List<HololiveModel>? live { get; set; }
        public List<HololiveModel>? upcoming { get; set; }
        public List<HololiveModel>? ended { get; set; }
        public bool? cached { get; set; }
    }
}
