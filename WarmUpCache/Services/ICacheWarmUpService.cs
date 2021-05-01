using System.Threading.Tasks;

namespace WarmUpCache.Services
{
    public interface ICacheWarmUpService
    {
        Task WarmUp();
    }
}