using HoloTracker.Models;

namespace HoloTracker
{
    public interface IHololiveApiService
    {
        Task<AllHololiveModel> GetLive();
    }
}
