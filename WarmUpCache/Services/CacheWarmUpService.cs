using System.Threading.Tasks;
using Serilog;

namespace WarmUpCache.Services
{
    public class CacheWarmUpService : ICacheWarmUpService
    {
        private ICityService _cityService;

        public CacheWarmUpService(ICityService cityService)
        {
            _cityService = cityService;   
        }
        
        public async Task WarmUp()
        {            
            _cityService.GetCityListFromCache();
            Log.Information("{Data} Warm Up On Start!", "CityList");
        }
    }
}