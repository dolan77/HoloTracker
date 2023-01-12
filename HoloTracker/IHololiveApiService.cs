using HoloTracker.Models;

namespace HoloTracker
{
    public interface IHololiveApiService
    {
        Task<List<HololiveModel>> GetLive(string a);
    }
}
